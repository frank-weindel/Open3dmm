using System;
using System.Runtime.InteropServices;

namespace Open3dmm.Classes
{
    [Vtable(0x4dd200)]
    public unsafe partial class BASE : NativeObject
    {
        private static readonly int classID = ClassID.ValueFromString("BASE");

        [HookFunction(FunctionNames.BASE_Init, CallingConvention = CallingConvention.ThisCall)]
        public static IntPtr BASE_Init(IntPtr address)
        {
            var h = NativeHandle.Dereference(address);
            var obj = h.ChangeType<BASE>();
            obj.Vtable = new VTABLE(0x4dd200);
            obj.NumReferences = 1;
            return address;
        }

        [HookFunction(FunctionNames.BASE_DecreaseReferenceCounter, CallingConvention = CallingConvention.ThisCall)]
        public virtual void DecreaseReferenceCounter()
        {
            if (--NumReferences < 1 && this != null)
            {
#if NATIVEDEP
                this.VirtualCall(0x8, new IntPtr(1));
#else
                Free(1);
#endif
            }
        }

        [HookFunction(FunctionNames.BASE_Free, CallingConvention = CallingConvention.ThisCall)]
        public virtual IntPtr Free(byte free)
        {
            var address = NativeHandle.Address;
            var obj = NativeHandle.ChangeType<BASE>();
            obj.Vtable = new VTABLE(0x4dd200);
            if ((free & 1) != 0)
                Program.Free(address);
            return address;
        }

        [HookFunction(FunctionNames.BASE_GetClassID, CallingConvention = CallingConvention.ThisCall)]
        public virtual int GetClassID()
        {
            return classID;
        }

        [HookFunction(FunctionNames.BASE_IncreaseReferenceCounter, CallingConvention = CallingConvention.ThisCall)]
        public virtual void IncreaseReferenceCounter()
        {
            NumReferences++;
        }

        [HookFunction(FunctionNames.BASE_IsDerivedFrom, CallingConvention = CallingConvention.ThisCall)]
        public virtual bool IsDerivedFrom(int classID)
        {
            return BASE.classID == classID;
        }
    }
}
