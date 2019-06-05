using Open3dmm.WinApi;
using System;
using System.Buffers.Binary;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;

namespace Open3dmm
{
    public interface IHook
    {
        void Initialize();
    }

    abstract unsafe class HookBase<TDelegate> : IHook
    {
        private readonly IntPtr functionPointer;

        public TDelegate FunctionDelegate { get; private set; }

        private bool isInitialized;
        private long restore;

        protected HookBase(IntPtr functionPointer)
        {
            this.functionPointer = functionPointer;
        }

        public void Initialize()
        {
            if (isInitialized)
                throw new InvalidOperationException("Hook is already initialized");
            FunctionDelegate = GetDelegate();
            long b = 0;
            Buffer.MemoryCopy(functionPointer.ToPointer(), &b, 8, 5);
            restore = b;
            isInitialized = true;
            CallOriginalPost();
        }

        public void CallOriginalPre()
        {
            if (!isInitialized)
                throw new InvalidOperationException("Hook is not initialized");
            var hproc = Process.GetCurrentProcess().Handle;
            Kernel32.WriteProcessMemory(hproc, this.functionPointer, restore, 5, out _);
        }

        public void CallOriginalPost()
        {
            if (!isInitialized)
                throw new InvalidOperationException("Hook is not initialized");
            var hproc = Process.GetCurrentProcess().Handle;
            const byte JMP = 0xE9;
            Kernel32.WriteProcessMemory(hproc, this.functionPointer, JMP, 1, out _);
            Kernel32.WriteProcessMemory(hproc, this.functionPointer + 1, Marshal.GetFunctionPointerForDelegate(FunctionDelegate).ToInt32() - this.functionPointer.ToInt32() - 5, 4, out _);
        }

        public T CallOriginal<T>(Func<TDelegate, T> invoker)
        {
            CallOriginalPre();
            var result = invoker(Marshal.GetDelegateForFunctionPointer<TDelegate>(functionPointer));
            CallOriginalPost();
            return result;
        }

        public void CallOriginal(Action<TDelegate> invoker)
        {
            CallOriginalPre();
            invoker(Marshal.GetDelegateForFunctionPointer<TDelegate>(functionPointer));
            CallOriginalPost();
        }

        protected abstract TDelegate GetDelegate();
    }
    public class HookContext<TDelegate> where TDelegate : Delegate
    {
        private HookBase<TDelegate> hook;

        internal HookContext(HookBase<TDelegate> hook)
        {
            this.hook = hook;
        }

        public T CallOriginal<T>(Func<TDelegate, T> invoker)
        {
            return hook.CallOriginal(invoker);
        }

        public void CallOriginal(Action<TDelegate> invoker)
        {
            hook.CallOriginal(invoker);
        }

        public IntPtr ToIntPtr(in bool value)
        {
            return value ? new IntPtr(1) : IntPtr.Zero;
        }

        public IHook Hook => hook;
    }
    public static class Hook
    {
        static List<IHook> trackers = new List<IHook>();

        public static void CreateHook<TDelegate>(IntPtr functionPointer, MethodInfo methodInfo) where TDelegate : Delegate
        {
            var callback = (TDelegate)Delegate.CreateDelegate(typeof(TDelegate), null, methodInfo);
            var hook = new DelegateHook<TDelegate>(functionPointer, ctx => callback);
            trackers.Add(hook);
            hook.Initialize();

            var paramGroup = methodInfo.GetParameters().Select(p => (p, a: p.GetCustomAttribute<RegisterParamAttribute>()));
            if (paramGroup.Any(tup => tup.a != null))
            {
                var ufpAttr = typeof(TDelegate).GetCustomAttribute<UnmanagedFunctionPointerAttribute>();
                if (ufpAttr?.CallingConvention == CallingConvention.ThisCall)
                    paramGroup = paramGroup.Skip(1); // skip 'this' parameter
                using (var mem = new MemoryStream(256))
                {
                    var retSize = paramGroup.Count(tup => tup.a == null) * IntPtr.Size;
                    var localStorage = retSize;
                    foreach (var (p, a) in paramGroup.Reverse())
                    {
                        if (a != null)
                        {
                            switch (a.Storage)
                            {
                                case Registers.ESI:
                                    // push ESI
                                    mem.WriteByte(0x56);
                                    break;
                                case Registers.EBP:
                                    // push EBP
                                    mem.WriteByte(0x55);
                                    break;
                                case Registers.EBX:
                                    // push EBX
                                    mem.WriteByte(0x53);
                                    break;
                                case Registers.ECX:
                                    // push ECX
                                    mem.WriteByte(0x51);
                                    break;
                                default:
                                    // push 0
                                    mem.WriteByte(0x6A);
                                    mem.WriteByte(0x00);
                                    break;
                            }
                            localStorage += IntPtr.Size;
                        }
                        else
                        {
                            // push Stack[localStorage]
                            mem.WriteByte(0xFF);
                            mem.WriteByte(0x74);
                            mem.WriteByte(0x24);
                            mem.WriteByte((byte)localStorage);
                        }
                    }
                    // call
                    const byte CALL = 0xE8;
                    mem.WriteByte(CALL);
                    int callOffset = (int)mem.Position;
                    mem.WriteByte(0);
                    mem.WriteByte(0);
                    mem.WriteByte(0);
                    mem.WriteByte(0);

                    // ret retSize
                    mem.WriteByte(0xC2);
                    mem.WriteByte((byte)retSize);

                    var codeArray = mem.ToArray();
                    var wrapperAddress = (int)VirtualAlloc(IntPtr.Zero, new IntPtr(codeArray.Length), MEM_COMMIT | MEM_RESERVE, PAGE_EXECUTE_READWRITE);
                    var callAddr = Marshal.GetFunctionPointerForDelegate(hook.FunctionDelegate).ToInt32();
                    BinaryPrimitives.WriteInt32LittleEndian(codeArray.AsSpan(callOffset, 4), callAddr + 1 - wrapperAddress - callOffset - 5);
                    var hproc = Process.GetCurrentProcess().Handle;

                    // Write wrapper code to virtualalloc space
                    Kernel32.WriteProcessMemory(hproc, new IntPtr(wrapperAddress), codeArray, codeArray.Length, out _);

                    // Rewrite hook instructions
                    //Kernel32.WriteProcessMemory(hproc, functionPointer, CALL, 1, out _);
                    Kernel32.WriteProcessMemory(hproc, functionPointer + 1, wrapperAddress - functionPointer.ToInt32() - 5, 4, out _);
                }
            }
        }

        public static IHook Create<TDelegate>(IntPtr functionPointer, Func<HookContext<TDelegate>, TDelegate> getCallback) where TDelegate : Delegate
        {
            var hook = new DelegateHook<TDelegate>(functionPointer, getCallback);
            trackers.Add(hook);
            return hook;
        }

        private class DelegateHook<TDelegate> : HookBase<TDelegate> where TDelegate : Delegate
        {
            private readonly Func<HookContext<TDelegate>, TDelegate> getCallback;

            public DelegateHook(IntPtr functionPointer, Func<HookContext<TDelegate>, TDelegate> getCallback) : base(functionPointer)
            {
                this.getCallback = getCallback;
            }

            protected override TDelegate GetDelegate()
            {
                return getCallback(new HookContext<TDelegate>(this));
            }
        }

        const uint MEM_COMMIT = 0x1000;

        const uint MEM_RESERVE = 0x2000;

        const uint MEM_RELEASE = 0x8000;

        const uint PAGE_EXECUTE_READWRITE = 0x40;

        [DllImport("kernel32", SetLastError = true)]

        static extern IntPtr VirtualAlloc(IntPtr startAddress, IntPtr size, uint allocationType, uint protectionType);

        [DllImport("kernel32", SetLastError = true)]

        static extern IntPtr VirtualFree(IntPtr address, IntPtr size, uint freeType);
    }
}
