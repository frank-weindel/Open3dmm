namespace Open3dmm.Classes
{
    public class ACTN : BACO
    {
        public Ref<GG> Cells => GetReference<GG>(0x0018);
        public Ref<GL> Transforms => GetReference<GL>(0x001C);
    }
}
