using System;
using System.Runtime.InteropServices;

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

        public IntPtr this[int index] => Marshal.ReadIntPtr(Address, index * 0x4);
    }
}
