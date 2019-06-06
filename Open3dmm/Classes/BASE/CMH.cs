using System;
using System.Runtime.InteropServices;

namespace Open3dmm.Classes
{
    public unsafe class CMH : BASE
    {
        [NativeFieldOffset(0x8)]
        public extern ref int Flags_8 { get; }

        [HookFunction(FunctionNames.CMH_Init, CallingConvention = CallingConvention.ThisCall)]
        public static IntPtr CMH_Init(IntPtr address, int flags)
        {
            BASE_Init(address);
            var h = NativeHandle.Dereference(address);
            var obj = h.ChangeType<CMH>();
            obj.Vtable = new VTABLE(0x4df0a0);
            obj.Flags_8 = flags;
            return address;
        }

        [HookFunction(FunctionNames.CMH_IsDerivedFrom, CallingConvention = CallingConvention.ThisCall)]
        [HookFunction(FunctionNames.CMH__IsDerivedFrom, CallingConvention = CallingConvention.ThisCall)]
        public override bool IsDerivedFrom(int classID)
        {
            return classID == 0x434d48 || base.IsDerivedFrom(classID);
        }

        [HookFunction(FunctionNames.CMH_GetClassID, CallingConvention = CallingConvention.ThisCall)]
        public override int GetClassID()
        {
            return 0x434d48;
        }

        [HookFunction(FunctionNames.CMH_Free, CallingConvention = CallingConvention.ThisCall)]
        public override IntPtr Free(byte free)
        {
            var address = NativeHandle.Address;
            _Free();
            if ((free & 1) != 0)
                Program.Free(address);
            return address;
        }

        [HookFunction(FunctionNames.CMH_VirtualFunc6, CallingConvention = CallingConvention.ThisCall)]
        public virtual IntPtr VirtualFunc6()
        {
            return new IntPtr(0x004e3b88);
        }

        [HookFunction(FunctionNames.CMH_VirtualFunc7, CallingConvention = CallingConvention.ThisCall)]
        public virtual bool VirtualFunc7(int depth, uint mask, int* dest)
        {
            int iVar1;
            int* somePointer;
            int* piVar2;
            int* piVar3;

            piVar3 = (int*)0x0;
            somePointer = (int*)this.VirtualCall(0x14).ToPointer();
            do
            {
                if (somePointer == null)
                {
                    if (piVar3 == null)
                    {
                        return false;
                    }
                    *dest = *piVar3;
                    dest[1] = piVar3[1];
                    dest[2] = piVar3[2];
                    dest[3] = piVar3[3];
                    return true;
                }
                piVar2 = (int*)somePointer[1];
                iVar1 = *piVar2;
                while (iVar1 != 0)
                {
                    if ((*piVar2 == depth) && ((piVar2[3] & mask) != 0))
                    {
                        *dest = *piVar2;
                        dest[1] = piVar2[1];
                        dest[2] = piVar2[2];
                        dest[3] = piVar2[3];
                        return true;
                    }
                    piVar2 = piVar2 + 4;
                    iVar1 = *piVar2;
                }
                if (((piVar2[1] != 0) && ((piVar2[3] & mask) != 0)) && (piVar3 == (int*)0x0))
                {
                    piVar3 = piVar2;
                }
                somePointer = (int*)*somePointer;
            } while (true);
        }

        [HookFunction(FunctionNames.CMH__Free, CallingConvention = CallingConvention.ThisCall)]
        public void _Free()
        {
            Vtable = new VTABLE(0x4df0a0);
            APP.GlobalAPPInstance?.VirtualCall(0x7c, NativeHandle.Address);
            Vtable = new VTABLE(0x4dd200);
        }
    }
}
