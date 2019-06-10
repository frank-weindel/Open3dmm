using System.Runtime.InteropServices;

namespace Open3dmm.Classes
{
    public unsafe class GNV : BASE
    {
        [NativeFieldOffset(0x008)]
		public extern ref Ref<GPT> GPT { get; }
        [NativeFieldOffset(0x0C)]
        public extern ref RECTANGLE TransformFrom { get; }
        [NativeFieldOffset(0x1C)]
        public extern ref RECTANGLE TransformTo { get; }
        [NativeFieldOffset(0x68)]
        public extern ref GNV_UnkStruct1 UnkStruct { get; }


        [HookFunction(FunctionNames.GNV_BlitMBMP, CallingConvention = CallingConvention.ThisCall)]
        public void BlitMBMP(MBMP mbmp, int offsetX, int offsetY)
        {
            RECTANGLE mbmpRect;
            RECTANGLE dest;

            mbmp.GetRect(out mbmpRect);
            mbmpRect.Offset(offsetX - mbmpRect.Left, offsetY - mbmpRect.Top);
            if (FUN_00422050(&mbmpRect, &dest))
            {
                GPT.Value.BlitMBMP(mbmp, &dest, (GNV_UnkStruct1*)UnkStruct.AsPointer());
            }
        }

        [HookFunction(FunctionNames.GNV_FUN_00422050, CallingConvention = CallingConvention.ThisCall)]
        public bool FUN_00422050(RECTANGLE* src, RECTANGLE* dest)
        {
            RECTANGLE srcCopy;
            srcCopy.Left = src->Left;
            srcCopy.Top = src->Top;
            srcCopy.Right = src->Right;
            srcCopy.Bottom = src->Bottom;
            var transformFrom = TransformFrom;
            var transformTo = TransformTo;
            srcCopy.Transform(&transformFrom, &transformTo);
            srcCopy.ToGDI(dest);
            return dest->Right != dest->Left && dest->Left <= dest->Right && (dest->Top < dest->Bottom);
        }
    }
}
