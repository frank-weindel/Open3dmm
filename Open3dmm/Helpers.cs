using Open3dmm.BRender;
using System;

namespace Open3dmm
{
    public static unsafe class Helpers
    {
        [HookFunction(0x004198c0, CallingConvention = System.Runtime.InteropServices.CallingConvention.StdCall)]
        public static void ScaleCalculation(int value, BrScalar scale, int* hiResult, int* loResult)
        {
            ScaleCalculation(value, scale, out var result);
            *hiResult = (int)(result >> 0x20);
            *loResult = (int)result;
        }

        public static void ScaleCalculation(int value, BrScalar scale, out long result)
        {
            result = (long)value * scale.ToFixed();
        }

        [HookFunction(0x00462080, CallingConvention = System.Runtime.InteropServices.CallingConvention.StdCall)]
        public static int timeGetTime()
        {
            return Environment.TickCount;
        }
    }
}
