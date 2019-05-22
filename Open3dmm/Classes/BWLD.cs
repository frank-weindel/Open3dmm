using Microsoft.Xna.Framework;
using Open3dmm.BRender;
using Open3dmm.Graphics;
using System;

namespace Open3dmm.Classes
{
    public class BWLD : BASE
    {
        private BrWorldRenderer renderer;

        public Pointer<int> Width1 => GetField<int>(0x10);

        public Pointer<int> Height1 => GetField<int>(0x14);

        public Pointer<int> Width2 => GetField<int>(0x20);

        public Pointer<int> Height2 => GetField<int>(0x24);

        public Pointer<IntPtr> RenderHandlers => GetField<IntPtr>(0x30);

        public Ref<BWLD> Field003C => GetReference<BWLD>(0x003C);

        public Ref<GPT> Bitmap1 => GetReference<GPT>(0x0100);

        public Ref<GPT> Bitmap2 => GetReference<GPT>(0x0104);

        public Pointer<int> Color => GetField<int>(0x10C);

        public Ref<ZBMP> Field0130 => GetReference<ZBMP>(0x0130);

        public Ref<ZBMP> Field0134 => GetReference<ZBMP>(0x0134);

        public Pointer<int> Depth => GetField<int>(0x138);

        public Ref<REGN> Field015C => GetReference<REGN>(0x015C);

        public Ref<REGN> Field0160 => GetReference<REGN>(0x0160);

        public Pointer<bool> DirtyFlag => GetField<bool>(0x16C);
        public Pointer<bool> SkipHandlers => GetField<bool>(0x170);

        public Ref<CRF> Field0184 => GetReference<CRF>(0x0184);

        public Pointer<BrActor> World => GetField<BrActor>(0x28);
        public Pointer<BrActor> Camera => GetField<BrActor>(0x84);
        public Pointer<BrPixelMap> PixelMap1 => GetField<BrPixelMap>(0x84);
        public Pointer<BrMatrix34> Matrix => GetField<BrMatrix34>(0x50);

        protected override void Initialize()
        {
            base.Initialize();
            renderer = new BrWorldRenderer(this);
            NativeAbstraction.GameTimer.Draw += OnRender;
        }

        private void OnRender(GameTime gameTime)
        {
            if (NativeHandle.IsDisposed)
                NativeAbstraction.GameTimer.Draw -= OnRender;
            else
                renderer.Render();
        }
    }
}
