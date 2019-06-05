using Microsoft.Xna.Framework;
using Open3dmm.BRender;
using Open3dmm.Graphics;
using System;

namespace Open3dmm.Classes
{
    public class BWLD : BASE
    {
        private BrWorldRenderer renderer;

        [NativeFieldOffset(0x10)]
        public extern ref int Width1 { get; }

        [NativeFieldOffset(0x14)]
        public extern ref int Height1 { get; }

        [NativeFieldOffset(0x20)]
        public extern ref int Width2 { get; }

        [NativeFieldOffset(0x24)]
        public extern ref int Height2 { get; }

        [NativeFieldOffset(0x30)]
        public extern ref IntPtr RenderHandlers { get; }

        [NativeFieldOffset(0x003C)]
		public extern ref Ref<BWLD> Field003C { get; }

        [NativeFieldOffset(0x0100)]
		public extern ref Ref<GPT> Bitmap1 { get; }

        [NativeFieldOffset(0x0104)]
		public extern ref Ref<GPT> Bitmap2 { get; }

        [NativeFieldOffset(0x10C)]
        public extern ref int Color { get; }

        [NativeFieldOffset(0x0130)]
		public extern ref Ref<ZBMP> Field0130 { get; }

        [NativeFieldOffset(0x0134)]
		public extern ref Ref<ZBMP> Field0134 { get; }

        [NativeFieldOffset(0x138)]
        public extern ref int Depth { get; }

        [NativeFieldOffset(0x015C)]
		public extern ref Ref<REGN> Field015C { get; }

        [NativeFieldOffset(0x0160)]
		public extern ref Ref<REGN> Field0160 { get; }

        [NativeFieldOffset(0x16C)]
        public extern ref bool DirtyFlag { get; }
        [NativeFieldOffset(0x170)]
        public extern ref bool SkipHandlers { get; }

        [NativeFieldOffset(0x0184)]
		public extern ref Ref<CRF> Field0184 { get; }

        [NativeFieldOffset(0x28)]
        public extern ref BrActor World { get; }
        [NativeFieldOffset(0x84)]
        public extern ref BrActor Camera { get; }
        [NativeFieldOffset(0x84)]
        public extern ref BrPixelMap PixelMap1 { get; }
        [NativeFieldOffset(0x50)]
        public extern ref BrMatrix34 Matrix { get; }

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
