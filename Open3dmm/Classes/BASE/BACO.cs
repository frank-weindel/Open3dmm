namespace Open3dmm.Classes
{
    public class BACO : BASE
    {
        [NativeFieldOffset(0x08)]
		public extern ref Ref<CRF> CRF { get; }
        [NativeFieldOffset(0x0C)]
        public extern ref QuadIDPair QuadIDPair { get; }
    }
}
