using Open3dmm.BRender;

namespace Open3dmm.Classes
{
    public class APE : GOB
    {
        public Pointer<BrActor> Light => GetField<BrActor>(0x00EC);
        public Pointer<BrMatrix34> Matrix => GetField<BrMatrix34>(0x0114);
    }
}
