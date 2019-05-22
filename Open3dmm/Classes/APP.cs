using Microsoft.Xna.Framework;
using System;
using System.Runtime.InteropServices;

namespace Open3dmm.Classes
{
    public class APP : APPB
    {
        private static RGBQUAD[] palette;

        public static APP Instance => FromPointer<APP>(new IntPtr(0x4D4120));
        public static RGBQUAD[] Palette => palette ?? (palette = ManagedArray.FromPointer<RGBQUAD>(new IntPtr(0x004E3CA4), 256));
        public static int PaletteVersion => Marshal.ReadInt32(new IntPtr(0x004E3CA8));
        public static int FlushCounter => Marshal.ReadInt32(new IntPtr(0x004E3CAC));

        [HookFunction(0x00407610, CallingConvention = CallingConvention.ThisCall)]
        public void AppMain(int param_1, int param_2, int param_3)
        {
            UnmanagedFunctionCall.StdCall(new IntPtr(0x00407ad0));
            FUN_0041bf30(param_1, param_2, param_3);
        }

        [HookFunction(0x0041bf30, CallingConvention = CallingConvention.ThisCall)]
        public void FUN_0041bf30(int param_1, int param_2, int param_3)
        {
            IntPtr iVar1;
            iVar1 = this.VirtualCall(0x24, new IntPtr(param_1), new IntPtr(param_2), new IntPtr(param_3));
            if (iVar1 != IntPtr.Zero)
            {
                this.VirtualCall(0x30);
            }
            this.VirtualCall(0x34);
            return;
        }
    }
}
