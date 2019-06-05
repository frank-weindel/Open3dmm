using Open3dmm.BRender;

namespace Open3dmm.Classes
{
    public class BKGD : BACO
    {
        [NativeFieldOffset(0x34)]
        public extern ref BrMatrix34 WorldMatrix { get; }
    }
}
