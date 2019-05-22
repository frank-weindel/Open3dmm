namespace Open3dmm.Classes
{
    public class APPB : CMH
    {
        public Pointer<int> Flags00C => GetField<int>(0x00C);

        public Pointer<int> RenderMode => GetField<int>(0x05C);
        public Ref<GPT> GPT => GetReference<GPT>(0x01C);

        public Ref<STIO> STIO => GetReference<STIO>(0x08C);
        public Ref<KWA> KWA => GetReference<KWA>(0x01BC);

        public Ref<GL> ListSometimes => GetReference<GL>(0x68);
    }
}
