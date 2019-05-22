namespace Open3dmm.Classes
{
    public class TBXG : TXRG
    {
        public Pointer<RECTANGLE> Rectangle  =>  GetField<RECTANGLE>(0x00D4);
    }
}
