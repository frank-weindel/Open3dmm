namespace Open3dmm.Classes
{
    public class TBXB : GOB
    {
        public Pointer<RECTANGLE> Rectangle  =>  GetField<RECTANGLE>(0x0084);
    }
}
