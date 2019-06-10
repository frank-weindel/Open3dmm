using System;
using System.Runtime.InteropServices;

namespace Open3dmm
{
    [AttributeUsage(AttributeTargets.Parameter, Inherited = false, AllowMultiple = false)]
    sealed class RegisterParamAttribute : Attribute
    {
        public Registers Storage { get; }

        public RegisterParamAttribute(Registers storage)
        {
            Storage = storage;
        }
    }
}
