using Open3dmm.WinApi;
using System;
using System.Runtime.InteropServices;

namespace Open3dmm.Classes
{
    public unsafe class GOB : CMH
    {
        [NativeFieldOffset(0x0C)]
        public extern ref IntPtr HWND { get; }
        [NativeFieldOffset(0x10)]
		public extern ref Ref<GPT> GPT { get; }

        [NativeFieldOffset(0x18)]
        public extern ref RECTANGLE Rect { get; }
        
        [NativeFieldOffset(0x28)]
        public extern ref RECTANGLE ClipRect { get; }

        [NativeFieldOffset(0x58)]
		public extern ref Ref<GOB> Parent { get; }
        [NativeFieldOffset(0x5C)]
		public extern ref Ref<GOB> FirstChild { get; }
        [NativeFieldOffset(0x60)]
        public extern ref Ref<GOB> Next { get; }

        [NativeFieldOffset(0x6C)]
        public extern ref uint Flags_6C { get; }

        [HookFunction(FunctionNames.GOB_Init, CallingConvention = CallingConvention.ThisCall)]
        public static IntPtr GOB_Init(IntPtr address, AutoClass1_Rectangles* flags)
        {
            CMH_Init(address, flags->Unk1);
            var h = NativeHandle.Dereference(address);
            var obj = h.ChangeType<GOB>();
            obj.Vtable = new VTABLE(0x4df198);
            UnmanagedFunctionCall.ThisCall(new IntPtr(0x00422DE0), address, new IntPtr(flags));
            return address;
        }

        [HookFunction(FunctionNames.GOB_Update, CallingConvention = CallingConvention.ThisCall)]
        public void Update()
        {
            RECTANGLE rect;
            RECTANGLE windowUpdateRect;
            var hwnd = GetWindowRect(&rect);
            if (hwnd != IntPtr.Zero)
            {
                APP.GlobalAPPInstance.VirtualCall(0xa0, hwnd);
                PInvoke.Call(LibraryNames.USER32, "GetUpdateRect", hwnd, new IntPtr(&windowUpdateRect), IntPtr.Zero);
                if (rect.CalculateIntersection(&windowUpdateRect))
                {
                    PInvoke.Call(LibraryNames.USER32, "UpdateWindow", hwnd);
                }
            }
        }

        [HookFunction(FunctionNames.GOB_GetWindowRect, CallingConvention = CallingConvention.ThisCall)]
        public IntPtr GetWindowRect(RECTANGLE* dest)
        {
            POINT position;
            *dest = Rect;
            var hwnd = GetPosition(&position, CoordinateSpace.Window);
            dest->Offset(position.X - Rect.Left,
                         position.Y - Rect.Top);
            return hwnd;
        }

        [HookFunction(FunctionNames.GOB_GetRect, CallingConvention = CallingConvention.ThisCall)]
        public void GetRect(RECTANGLE* dest, CoordinateSpace space)
        {
            POINT position;
            *dest = Rect;
            GetPosition(&position, space);
            dest->Offset(position.X - Rect.Left,
                         position.Y - Rect.Top);
        }

        [HookFunction(FunctionNames.GOB_ClipRect, CallingConvention = CallingConvention.ThisCall)]
        public void GetClipRect(RECTANGLE* dest, CoordinateSpace space)
        {
            POINT position;
            *dest = ClipRect;
            GetPosition(&position, space);
            dest->Offset(position.X - Rect.Left,
                         position.Y - Rect.Top);
        }

        [HookFunction(FunctionNames.GOB_GetPosition, CallingConvention = CallingConvention.ThisCall)]
        public IntPtr GetPosition(POINT* dest, CoordinateSpace space)
        {
            var @this = this;
            GOB parent;
            GOB pGVar3;
            GOB current;
            IntPtr hWnd;
            POINT tmp;

            hWnd = IntPtr.Zero;
            switch (space)
            {
                case CoordinateSpace.Local:
                    dest->X = @this.Rect.Left;
                    dest->Y = @this.Rect.Top;
                    break;
                case CoordinateSpace.GPT:
                    dest->Y = 0;
                    dest->X = 0;
                    parent = @this.Parent;
                    current = @this;
                    if (@this.Parent.Value!= null)
                    {
                        while ((pGVar3 = parent).GPT.Value== @this.GPT.Value)
                        {
                            dest->X += current.Rect.Left;
                            dest->Y += current.Rect.Top;
                            parent = pGVar3.Parent.Value;
                            current = pGVar3;
                            if (pGVar3.Parent.Value== null)
                                break;
                        }
                    }
                    break;
                case CoordinateSpace.Window:
                case CoordinateSpace.Screen:
                    dest->Y = 0;
                    dest->X = 0;
                    if (@this != null)
                    {
                        do
                        {
                            if (@this.HWND != IntPtr.Zero) break;
                            dest->X = dest->X + @this.Rect.Left;
                            dest->Y = dest->Y + @this.Rect.Top;
                            @this = @this.Parent;
                        } while (@this != null);
                        if (@this != null)
                        {
                            hWnd = @this.HWND;
                        }
                    }
                    if ((space == CoordinateSpace.Screen) && (hWnd != IntPtr.Zero))
                    {
                        PInvoke.Call(LibraryNames.USER32, "ClientToScreen", hWnd, new IntPtr(dest->ToGDI(&tmp)));
                        *dest = tmp;
                    }
                    break;
                default:
                    dest->Y = 0;
                    dest->X = 0;
                    break;
            }
            return hWnd;
        }

        [HookFunction(FunctionNames.GOB_FUN_00424580, CallingConvention = CallingConvention.ThisCall)]
        public GOB FUN_00424580(int offsetX, int offsetY, POINT* unk)
        {
            offsetX -= Rect.Left;
            offsetY -= Rect.Top;
            if (this.VirtualCall(0x50, new IntPtr(offsetX), new IntPtr(offsetY)) != IntPtr.Zero)
            {
                var child = FirstChild.Value;
                while (child != null)
                {
                    var result = child.FUN_00424580(offsetX, offsetY, unk);
                    if (result != null)
                        return result;
                    child = child.Next.Value;
                }
            }

            if (this.VirtualCall(0x4c, new IntPtr(offsetX), new IntPtr(offsetY)) == IntPtr.Zero)
                return null;

            if (unk != null)
            {
                unk->X = offsetX;
                unk->Y = offsetY;
            }
            return this;
        }

        [HookFunction(FunctionNames.GOB_HitTest, CallingConvention = CallingConvention.ThisCall)]
        public bool HitTest(int posX, int posY)
        {
            RECTANGLE rect;

            if (Flags_8 == 0x11)
            {
                return false;
            }
            GetRect(&rect, 0);
            return rect.HitTest(posX, posY);
        }

        [HookFunction(FunctionNames.GOB_GetHWND, CallingConvention = CallingConvention.ThisCall)]
        public IntPtr GetHWND()
        {
            var @this = this;
            while (@this != null)
            {
                if (@this.HWND != IntPtr.Zero)
                    return @this.HWND;
                @this = @this.Parent;
            }
            return IntPtr.Zero;
        }

        public GOB Previous {
            [HookFunction(FunctionNames.GOB_GetPrevious, CallingConvention = CallingConvention.ThisCall)]
            get {
                var element = GlobalRootGOB;

                if (Parent.Value!= null)
                {
                    element = Parent.Value.FirstChild.Value;
                }
                if (element == this || element == null)
                {
                    return null;
                }

                while (element.Next != this)
                    element = element.Next;

                return element;
            }
        }
    }
}
