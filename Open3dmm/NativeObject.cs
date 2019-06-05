using Open3dmm.Classes;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Open3dmm
{
    public unsafe class NativeObject : IEquatable<NativeObject>
    {
        private NativeHandle nativeHandle;

        public NativeHandle NativeHandle => nativeHandle;

        [NativeFieldOffset(0x0)]
        public extern ref VTABLE Vtable { get; }
        [NativeFieldOffset(0x4)]
        public extern ref int NumReferences { get; }

        internal void SetHandle(NativeHandle nativeHandle)
        {
            if (this.nativeHandle != null)
                throw new InvalidOperationException("Native object is already associated with a native handle");
            this.nativeHandle = nativeHandle;
            Initialize();
        }

        public static Pointer<T> GetGlobal<T>(int address) where T : unmanaged
        {
            return new Pointer<T>(new IntPtr(address));
        }

        public static T FromPointer<T>(IntPtr ptr) where T : NativeObject, new()
        {
            if (ptr == IntPtr.Zero)
                return default;
            if (!NativeHandle.TryDereference(ptr, out var handle))
                throw new InvalidOperationException();
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

        #region Equality Implementation

        public override bool Equals(object obj)
        {
            return Equals(obj as NativeObject);
        }

        public bool Equals(NativeObject other)
        {
            return other != null &&
                   EqualityComparer<IntPtr>.Default.Equals(this.nativeHandle.Address, other.nativeHandle.Address);
        }

        public override int GetHashCode()
        {
            return -2057323372 + EqualityComparer<IntPtr>.Default.GetHashCode(this.nativeHandle.Address);
        }

        public static bool operator ==(NativeObject left, NativeObject right)
        {
            return EqualityComparer<NativeObject>.Default.Equals(left, right);
        }

        public static bool operator !=(NativeObject left, NativeObject right)
        {
            return !(left == right);
        }

        #endregion
    }
}
