using Open3dmm.BRender;

namespace Open3dmm.Classes
{
    public unsafe class ACTR : BASE
    {
        [NativeFieldOffset(0xB0)]
        public extern ref BrMatrix34 OtherMatrix { get; }
        [NativeFieldOffset(0xF0)]
        public extern ref BrMatrix34 TransformMatrix { get; }
    }
}
