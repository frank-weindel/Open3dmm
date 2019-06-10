using System;

namespace Open3dmm
{
    [AttributeUsage(AttributeTargets.Class, Inherited = false, AllowMultiple = false)]
    sealed class VtableAttribute : Attribute
    {
        public VtableAttribute(int vtableAddress)
        {
            VtableAddress = vtableAddress;
        }

        public int VtableAddress { get; }
    }
}
