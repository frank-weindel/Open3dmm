using System;
using System.Runtime.InteropServices;

namespace Open3dmm.Classes
{
    public class BASE : NativeObject
    {
        [HookFunction(FunctionNames.BASE_Init, CallingConvention = CallingConvention.ThisCall)]
        public static IntPtr Init(IntPtr address)
        {
            Marshal.WriteInt32(address, 0x4dd200);
            Marshal.WriteInt32(address, 0x04, 1);
            return address;
        }

        //public static IntPtr Init(IntPtr address)
        //{
        //    unsafe
        //    {
        //        return UnmanagedFunctionCall.ThisCall((IntPtr)0x004190f0, address);
        //    }
        //}
    }
}
