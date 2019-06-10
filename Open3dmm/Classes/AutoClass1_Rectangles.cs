using System;

namespace Open3dmm.Classes
{
    public struct AutoClass1_Rectangles
    {
        public int Unk1;
        private IntPtr root;
        public GOB Root {
            get => NativeObject.FromPointer<GOB>(root);
            set => root = value?.NativeHandle.Address ?? IntPtr.Zero;
        }
        public int Field_0x8;
        public int Field_0xC;
        public RECTANGLE Rect2;
        public RECTANGLE Rect3;
    };
}
