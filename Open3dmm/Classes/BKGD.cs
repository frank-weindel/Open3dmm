using Open3dmm.BRender;

namespace Open3dmm.Classes
{
    public class BKGD : BACO
    {
        public Pointer<BrMatrix34> WorldMatrix  =>  GetField<BrMatrix34>(0x34);
    }
}
