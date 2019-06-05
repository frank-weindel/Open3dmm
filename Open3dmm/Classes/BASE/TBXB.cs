namespace Open3dmm.Classes
{
    public class TBXB : GOB
    {
        [NativeFieldOffset(0x0084)]
        public extern ref RECTANGLE Rectangle { get; }
    }
}
