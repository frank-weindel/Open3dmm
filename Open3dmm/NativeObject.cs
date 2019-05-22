using Open3dmm.Classes;
using System;
using System.Runtime.InteropServices;

namespace Open3dmm
{
    public class NativeObject
    {
        private NativeHandle nativeHandle;

        public NativeHandle NativeHandle => nativeHandle;
        public Pointer<VTABLE> Vtable => GetField<VTABLE>(0x00);
        public Pointer<int> NumReferences => GetField<int>(0x04);

        internal void SetHandle(NativeHandle nativeHandle)
        {
            if (this.nativeHandle != null)
                throw new InvalidOperationException("Native object is already associated with a native handle");
            this.nativeHandle = nativeHandle;
            Initialize();
        }

        protected Pointer<T> GetField<T>(int offset, bool boundsChecking = true) where T : unmanaged
        {
            return new Pointer<T>(CalculateAddressOfField(offset, boundsChecking));
        }

        protected Ref<T> GetReference<T>(int offset, bool boundsChecking = true) where T : NativeObject
        {
            return new Ref<T>(CalculateAddressOfField(offset, boundsChecking));
        }

        public static T FromPointer<T>(IntPtr ptr) where T : NativeObject
        {
            if (ptr == IntPtr.Zero)
                return default;
            if (!NativeHandle.TryDereference(ptr, out var handle))
                throw new InvalidCastException();
            return handle.QueryInterface<T>();
        }

        protected virtual void Initialize()
        {
        }

        protected void EnsureNotDisposed()
        {
            if (nativeHandle.IsDisposed)
                throw new ObjectDisposedException(GetType().Name);
        }

        [System.Runtime.ExceptionServices.HandleProcessCorruptedStateExceptions]
        public static bool TryGetClassID(NativeHandle nativeHandle, out ClassID classID)
        {
            try
            {
                if (!nativeHandle.IsDisposed)
                {
                    var func = Marshal.ReadIntPtr(Marshal.ReadIntPtr(nativeHandle.Address), 4);
                    if (func.ToInt32() < NativeAbstraction.ModuleHandle.ToInt32())
                        goto Fail;
                    classID = new ClassID((int)UnmanagedFunctionCall.ThisCall(func, nativeHandle.Address));
                    return true;
                }
            }
            catch
            {
            }

        Fail:
            classID = default;
            return false;
        }

        [System.Runtime.ExceptionServices.HandleProcessCorruptedStateExceptions]
        public static bool TypeCheck(NativeHandle nativeHandle, ClassID classID)
        {
            try
            {
                if (!nativeHandle.IsDisposed)
                {
                    return UnmanagedFunctionCall.ThisCall(Marshal.ReadIntPtr(Marshal.ReadIntPtr(nativeHandle.Address)), nativeHandle.Address, new IntPtr(classID.Value)) != IntPtr.Zero;
                }
            }
            catch
            {
            }

            return false;
        }

        private IntPtr CalculateAddressOfField(int offset, bool boundsChecking)
        {
            EnsureNotDisposed();
            if (boundsChecking && offset >= nativeHandle.Size)
                throw new InvalidOperationException("Attempted to read outside the boundaries of a native object");
            return nativeHandle.Address + offset;
        }

        public ref byte GetPinnableReference()
        {
            EnsureNotDisposed();
            unsafe
            {
                return ref *(byte*)nativeHandle.Address;
            }
        }
        public ClassID GetClassID()
        {
            EnsureNotDisposed();
            return new ClassID((int)UnmanagedFunctionCall.ThisCall(Marshal.ReadIntPtr(Vtable, 4), NativeHandle.Address));
        }
    }
}
