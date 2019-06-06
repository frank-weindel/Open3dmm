using Open3dmm.BRender;
using System.Runtime.InteropServices;

namespace Open3dmm.Classes
{
    [Vtable(0x4e2b68)]
    public unsafe class ACTR : BASE
    {
        private static readonly int classID = ClassID.ValueFromString("ACTR");

        [NativeFieldOffset(0xB0)]
        public extern ref BrMatrix34 OtherMatrix { get; }

        [NativeFieldOffset(0xF0)]
        public extern ref BrMatrix34 TransformMatrix { get; }

        [HookFunction(FunctionNames.ACTR_IsDerivedFrom, CallingConvention = CallingConvention.ThisCall)]
        public override bool IsDerivedFrom(int classID)
        {
            return classID == ACTR.classID || base.IsDerivedFrom(classID);
        }
    }
}
