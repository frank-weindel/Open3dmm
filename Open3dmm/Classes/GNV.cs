namespace Open3dmm.Classes
{
    public class GNV : BASE
    {
        public Ref<GPT> GPT => GetReference<GPT>(0x008);
        public Pointer<RECTANGLE> Field001C  =>  GetField<RECTANGLE>(0x1C);
    }
}
