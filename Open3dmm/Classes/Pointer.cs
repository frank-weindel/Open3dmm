using System;

namespace Open3dmm.Classes
{
    [System.Diagnostics.DebuggerDisplay("{DebuggerDisplay,nq}")]
    public unsafe ref struct Pointer<T> where T : unmanaged
    {
        private string DebuggerDisplay => Value.ToString();

        private readonly T* address;
        public ref T Value {
            get {
                unsafe
                {
                    return ref *address;
                }
            }
        }

        public T* ToPointer()
        {
            return address;
        }

        public Pointer(IntPtr address) : this((T*)address)
        {
        }

        public Pointer(T* address)
        {
            this.address = address;
        }

        public static implicit operator T(Pointer<T> pointer)
        {
            return pointer.Value;
        }
    }
}
