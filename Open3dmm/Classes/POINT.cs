using System;
using System.Runtime.InteropServices;

namespace Open3dmm.Classes
{
    public unsafe struct POINT
    {
        public int X;
        public int Y;

        public POINT(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }

        public static readonly POINT Zero = default;

        [HookFunction(FunctionNames.POINT_ToGDI, CallingConvention = CallingConvention.ThisCall)]
        public POINT* ToGDI(POINT* dest)

        {
            GDIHelper.LimitFunction(in X, out dest->X);
            GDIHelper.LimitFunction(in Y, out dest->Y);
            return dest;
        }
    }
}
