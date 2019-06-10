using Open3dmm.BRender;

namespace Open3dmm.Classes
{
    public unsafe class APE : GOB
    {
        [NativeFieldOffset(0x00EC)]
        public extern ref BrActor Light { get; }
        [NativeFieldOffset(0x0114)]
        public extern ref BrMatrix34 Matrix { get; }
    }
}
