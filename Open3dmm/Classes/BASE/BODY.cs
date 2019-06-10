namespace Open3dmm.Classes
{
    public class BODY : BASE
    {
        [NativeFieldOffset(0x24)]
        public extern ref RECTANGLE Rect { get; }
    }
}
