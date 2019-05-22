namespace Open3dmm.Classes
{
    public class BODY : BASE
    {
        public Pointer<RECTANGLE> Rect => GetField<RECTANGLE>(0x24);
    }
}
