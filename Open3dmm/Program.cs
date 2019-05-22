using Open3dmm.Classes;
using Open3dmm.WinApi;
using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Open3dmm
{
    public class Program
    {
        static int Main(string[] args)
        {
            RuntimeHelpers.RunClassConstructor(typeof(NativeAbstraction).TypeHandle);
            return __WinMainCRTStartup();
        }

        public static int Bootstrap(string pwzArgument)
        {
            var argStr = Marshal.PtrToStringUni(PInvoke.Call(LibraryNames.KERNEL32, "GetCommandLineW"));
            int exitCode = Main(argStr.Substring(argStr.IndexOf(' ') + 1).Split(' '));
            PInvoke.Call(LibraryNames.KERNEL32, "ExitProcess", new IntPtr(exitCode));
            return exitCode; //Should never be reached.
        }

        [HookFunction(FunctionNames.__WinMainCRTStartup, CallingConvention = CallingConvention.StdCall)]
        public static int __WinMainCRTStartup()
        {
            NativeAbstraction.GameTimer = new GameTimer();
            var envStrings = PInvoke.Call(LibraryNames.KERNEL32, "GetEnvironmentStrings");
            Marshal.WriteIntPtr((IntPtr)0x004EA1A4, envStrings);
            UnmanagedFunctionCall.StdCall((IntPtr)FunctionNames.__cinit);
            UnmanagedFunctionCall.StdCall((IntPtr)FunctionNames.WinMain, NativeAbstraction.ModuleHandle, IntPtr.Zero, IntPtr.Zero, IntPtr.Zero).ToInt32();
            return 0;
        }

        [HookFunction(0x004075f0, CallingConvention = CallingConvention.StdCall)]
        public static void AppMainStatic()
        {
            APP.Instance.AppMain(1, 0, 2);
        }

        [HookFunction(FunctionNames.Malloc, CallingConvention = CallingConvention.StdCall)]
        public static IntPtr Malloc(int size)
        {
            return NativeHandle.Alloc(size).Address;
        }

        [HookFunction(FunctionNames.Free, CallingConvention = CallingConvention.StdCall)]
        public static bool Free(IntPtr address)
        {
            NativeHandle.Free(address);
            return true;
        }
    }
}
