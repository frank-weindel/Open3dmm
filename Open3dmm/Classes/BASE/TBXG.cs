namespace Open3dmm.Classes
{
    public class TBXG : TXRG
    {
        [NativeFieldOffset(0x00D4)]
        public extern ref RECTANGLE Rectangle { get; }
    }
}
