using System;

namespace Open3dmm.Classes
{
    public struct VTABLE
    {
        public IntPtr Address;

        public VTABLE(int address) : this(new IntPtr(address))
        {
        }

        public VTABLE(IntPtr address)
        {
            Address = address;
        }
    }
}
