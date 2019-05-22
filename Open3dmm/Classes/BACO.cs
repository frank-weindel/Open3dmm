namespace Open3dmm.Classes
{
    public class BACO : BASE
    {
        public Ref<CRF> CRF => GetReference<CRF>(0x08);
        public Pointer<QuadIDPair> QuadIDPair => GetField<QuadIDPair>(0x0C);
    }
}
