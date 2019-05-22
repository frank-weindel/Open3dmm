using Open3dmm.WinApi;
using System;
using System.Runtime.InteropServices;

namespace Open3dmm.Classes
{
    public unsafe class REGN : BASE
    {
        public Pointer<RECTANGLE> Rectangle => GetField<RECTANGLE>(0x08);

        public Pointer<int> Unk1 => GetField<int>(0x18);

        public Ref<GLB> ParentList => GetReference<GLB>(0x1C);

        public Pointer<IntPtr> GdiHandle => GetField<IntPtr>(0x20);
        public Pointer<int> OffsetX => GetField<int>(0x24);
        public Pointer<int> OffsetY => GetField<int>(0x28);

        [HookFunction(FunctionNames.REGN_CopyRectAndReturnInvalid, CallingConvention = CallingConvention.ThisCall)]
        public bool CopyRectAndReturnInvalid(RECTANGLE* dest)
        {
            var r = Rectangle.Value;
            if (dest != null)
            {
                dest->Left = r.Left;
                dest->Top = r.Top;
                dest->Right = r.Right;
                dest->Bottom = r.Bottom;
            }
            return r.Top >= r.Bottom || r.Left >= r.Right;
        }

        [HookFunction(FunctionNames.REGN_FUN_00426380, CallingConvention = CallingConvention.ThisCall)]
        public unsafe bool FUN_00426380(RECTANGLE* dest)
        {
            if (dest != null)
            {
                dest->Left = Rectangle.Value.Left;
                dest->Top = Rectangle.Value.Top;
                dest->Right = Rectangle.Value.Right;
                dest->Bottom = Rectangle.Value.Bottom;
            }
            return ParentList.GetValue() == null;
        }

        [HookFunction(FunctionNames.REGN_Offset, CallingConvention = CallingConvention.ThisCall)]
        public unsafe void Offset(int offsetX, int offsetY)
        {
            Rectangle.Value.Offset(offsetX, offsetY);
            OffsetX.Value += offsetX;
            OffsetY.Value += offsetY;
        }

        [HookFunction(FunctionNames.REGN_FUN_004262A0, CallingConvention = CallingConvention.ThisCall)]
        public unsafe void FUN_004262A0(RECTANGLE* source)
        {
            if (source == null)
            {
                Rectangle.Value.Bottom = 0;
                Rectangle.Value.Right = 0;
                Rectangle.Value.Top = 0;
                Rectangle.Value.Left = 0;
            }
            else
            {
                Rectangle.Value.Left = source->Left;
                Rectangle.Value.Top = source->Top;
                Rectangle.Value.Right = source->Right;
                Rectangle.Value.Bottom = source->Bottom;
            }
            if (ParentList.GetValue() != null)
            {
                ParentList.GetValue().VirtualCall(0x10);
                ParentList.SetValue(null);
            }
            UnmanagedFunctionCall.StdCall(new IntPtr(0x0042b950), new IntPtr(GdiHandle.ToPointer()));
            Unk1.Value = 0;
        }

        [HookFunction(FunctionNames.REGN_GetOrCreateGdiHandle, CallingConvention = CallingConvention.ThisCall)]
        public unsafe IntPtr GetOrCreateGdiHandle()
        {
            IntPtr result;

            if (GdiHandle != IntPtr.Zero)
            {
                if ((OffsetX != 0) || (OffsetY != 0))
                {
                    PInvoke.Call(LibraryNames.GDI32, "OffsetRgn", GdiHandle, new IntPtr(OffsetX), new IntPtr(OffsetY));
                    OffsetY.Value = 0;
                    OffsetX.Value = 0;
                }
                return GdiHandle;
            }
            OffsetY.Value = 0;
            OffsetX.Value = 0;
            result = this.ThisCall(new IntPtr(0x00427aa0)); // FUN_00427aa0();
            return GdiHandle.Value = result;
        }
    }
}
