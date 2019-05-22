using System;

namespace Open3dmm.Classes
{
    [System.Diagnostics.DebuggerDisplay("{DebuggerDisplay,nq}")]
    public unsafe ref struct Ref<T> where T : NativeObject
    {
        private string DebuggerDisplay => GetValue().ToString();

        private readonly void** address;

        public T GetValue()
        {
            return NativeObject.FromPointer<T>(new IntPtr(*address));
        }

        public void SetValue(T value)
        {
            if (value == null)
                *address = null;
            else
                *address = (void*)value.NativeHandle.Address;
        }

        public void** ToPointer()
        {
            return address;
        }

        public Ref(IntPtr address) : this((void**)address)
        {
        }

        public Ref(void** address)
        {
            this.address = address;
        }

        public static implicit operator T(Ref<T> pointer)
        {
            return pointer.GetValue();
        }
    }
}
