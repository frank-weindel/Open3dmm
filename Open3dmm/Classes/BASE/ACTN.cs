namespace Open3dmm.Classes
{
    public class ACTN : BACO
    {
        [NativeFieldOffset(0x0018)]
		public extern ref Ref<GG> Cells { get; }
        [NativeFieldOffset(0x001C)]
		public extern ref Ref<GL> Transforms { get; }
    }
}
