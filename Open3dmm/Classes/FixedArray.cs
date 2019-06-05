using System;

namespace Open3dmm.Classes
{
    [System.Diagnostics.DebuggerDisplay("{DebuggerDisplay,nq}")]
    public unsafe readonly struct FixedArray<T> where T : unmanaged
    {
        private string DebuggerDisplay => typeof(T).Name + "[]";

        private readonly T** firstElement;

        public ref T this[int index] {
            get {
                return ref *(*firstElement + index);
            }
        }

        public T* ToPointer()
        {
            return *firstElement;
        }

        public FixedArray(IntPtr pointerToFirstElement) : this((T**)pointerToFirstElement)
        {
        }

        public FixedArray(T** pointerToFirstElement)
        {
            this.firstElement = pointerToFirstElement;
        }
    }
}
