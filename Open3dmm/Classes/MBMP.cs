using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Runtime.InteropServices;

namespace Open3dmm.Classes
{
    public class MBMP : BACO
    {
        public IntPtr Data => GetField<IntPtr>(0x1C);

        public unsafe bool Blit(IntPtr dest, int stride, int height, int offsetX, int offsetY, RECTANGLE* rect, REGN regn)
        {
            return UnmanagedFunctionCall.ThisCall((IntPtr)FunctionNames.MBMP_Blit, NativeHandle.Address, dest, new IntPtr(stride), new IntPtr(height), new IntPtr(offsetX), new IntPtr(offsetY), new IntPtr(rect), regn?.NativeHandle.Address ?? IntPtr.Zero) != IntPtr.Zero;
        }

        public bool GetRect(out RECTANGLE rect)
        {
            if (Data != IntPtr.Zero)
            {
                rect = Marshal.PtrToStructure<RECTANGLE>(Data + 8);
                return true;
            }
            rect = default;
            return false;
        }
    }
}
