using Open3dmm.BRender;

namespace Open3dmm.Classes
{
    public class ACTR : BASE
    {
        public Pointer<BrMatrix34> OtherMatrix => GetField<BrMatrix34>(0xB0);

        public Pointer<BrMatrix34> TransformMatrix => GetField<BrMatrix34>(0xF0);
    }
}
