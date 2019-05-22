using Open3dmm.WinApi;
using System;
using System.Runtime.InteropServices;

namespace Open3dmm.Classes
{
    public unsafe class GPT : BASE
    {
        public Ref<REGN> Region => GetReference<REGN>(0x08);
        public Pointer<RECTANGLE> ClipRect => GetField<RECTANGLE>(0x0C);
        public Pointer<int> OffsetX => GetField<int>(0x1C);
        public Pointer<int> OffsetY => GetField<int>(0x20);
        public Pointer<IntPtr> DC => GetField<IntPtr>(0x24);
        public Pointer<IntPtr> WindowHandle => GetField<IntPtr>(0x28);
        public Pointer<IntPtr> DIBPointer => GetField<IntPtr>(0x2C);
        public Pointer<IntPtr> PixelBuffer => GetField<IntPtr>(0x30);
        public Pointer<RECTANGLE> Bounds => GetField<RECTANGLE>(0x3C);
        public Pointer<int> BitDepth => GetField<int>(0x34);
        public Pointer<int> Stride => GetField<int>(0x38);
        public Pointer<int> FlushCounter => GetField<int>(0x50);
        public Pointer<int> Field_0x68 => GetField<int>(0x68);
        public Pointer<int> Field_0x80 => GetField<int>(0x80);
        public Pointer<int> Field_0x84 => GetField<int>(0x84);
        public Pointer<int> UnkFlags => GetField<int>(0x88);

        public int Width => Bounds.Value.Right - Bounds.Value.Left;
        public int Height => Bounds.Value.Bottom - Bounds.Value.Top;

        [HookFunction(FunctionNames.GPT__BlitMBMP, CallingConvention = CallingConvention.ThisCall)]
        public void BlitMBMP(MBMP mbmp, RECTANGLE* dest, GPT_UnkStruct1* unkStruct)
        {
            RECTANGLE clip = default;

            if (unkStruct->Clip != null)
            {
                clip.Copy(unkStruct->Clip);
                if (!clip.CalculateIntersection(dest))
                    return;
            }
            else
            {
                clip.Copy(dest);
            }

            mbmp.GetRect(out var mbmpRect); // call 0x0043F7D0 
            if (mbmpRect.Top < mbmpRect.Bottom && mbmpRect.Left < mbmpRect.Right)
            {
                if (BitDepth == 8)
                {
                    if (dest->Left - dest->Right + mbmpRect.Right != mbmpRect.Left || dest->Top - dest->Bottom + mbmpRect.Bottom != mbmpRect.Top)
                    {
                        // 0042B451
                        PInvoke.Call(LibraryNames.GDI32, "SetTextColor", DC, new IntPtr(0x2FFFFFF));
                        PInvoke.Call(LibraryNames.GDI32, "SetBkColor", DC, new IntPtr(0x2000000));
                        mbmpRect.TopLeftOrigin();
                        if (FromPointer<GPT>(UnmanagedFunctionCall.StdCall((IntPtr)FunctionNames.AllocateGPT, new IntPtr(&mbmpRect), new IntPtr(1))) is GPT gptMaskMaybe)
                        {
                            mbmp.ThisCall((IntPtr)FunctionNames.MBMP_Method00425850, gptMaskMaybe.PixelBuffer, (IntPtr)gptMaskMaybe.Stride.Value, new IntPtr(mbmpRect.Height), new IntPtr(-mbmpRect.Left), new IntPtr(-mbmpRect.Top), new IntPtr(&mbmpRect)); // call 0x00425850
                            //Method0042A550(unkStruct->Clip);
                            this.ThisCall((IntPtr)FunctionNames.GPT__Method0042A550, new IntPtr(unkStruct->Clip));
                            PInvoke.Call(LibraryNames.GDI32, "StretchBlt", DC, new IntPtr(dest->Left), new IntPtr(dest->Top), new IntPtr(dest->Width), new IntPtr(dest->Height), gptMaskMaybe.DC, IntPtr.Zero, IntPtr.Zero, new IntPtr(mbmpRect.Width), new IntPtr(mbmpRect.Height), new IntPtr(0xEE0086));
                            gptMaskMaybe.VirtualCall(0x10); // Free?

                            if (FromPointer<GPT>(UnmanagedFunctionCall.StdCall((IntPtr)FunctionNames.AllocateGPT, new IntPtr(&mbmpRect), new IntPtr(8))) is GPT gptColor)
                            {
                                RECTANGLE fill = default;
                                mbmpRect.SizeLimit(&fill);

                                PInvoke.Call(LibraryNames.USER32, "FillRect", gptColor.DC, new IntPtr(&fill), PInvoke.Call(LibraryNames.GDI32, "GetStockObject", IntPtr.Zero));
                                UnmanagedFunctionCall.StdCall((IntPtr)FunctionNames.GDIFlush);

                                mbmp.Blit(gptColor.PixelBuffer, gptColor.Stride, mbmpRect.Height, -mbmpRect.Left, -mbmpRect.Top, &mbmpRect, null);

                                PInvoke.Call(LibraryNames.GDI32, "StretchBlt", DC, new IntPtr(dest->Left), new IntPtr(dest->Top), new IntPtr(dest->Width), new IntPtr(dest->Height), gptColor.DC, IntPtr.Zero, IntPtr.Zero, new IntPtr(mbmpRect.Width), new IntPtr(mbmpRect.Height), new IntPtr(0x8800C6));
                                gptColor.VirtualCall(0x10); // Free?
                            }
                        }
                    }
                    else
                    {
                        // 0042B3F0

                        if (clip.CalculateIntersection(Bounds.ToPointer()))
                        {
                            if (FlushCounter >= APP.FlushCounter)
                                UnmanagedFunctionCall.StdCall((IntPtr)FunctionNames.GDIFlush);
                            int offsetX = dest->Left - mbmpRect.Left;
                            int offsetY = dest->Top - mbmpRect.Top;
                            mbmp.Blit(PixelBuffer, Stride, Bounds.Value.Height, offsetX, offsetY, &clip, Region);
                        }
                    }
                }
                else if (BitDepth == 32)
                {
                    if (clip.CalculateIntersection(Bounds.ToPointer()))
                    {
                        if (FlushCounter >= APP.FlushCounter)
                            UnmanagedFunctionCall.StdCall((IntPtr)FunctionNames.GDIFlush);
                        // TODO: Implement 32 bit GPT
                    }
                }
            }
        }

        [HookFunction(FunctionNames.GPT__Method0042A550, CallingConvention = CallingConvention.ThisCall)]
        public void FUN_0042a550(RECTANGLE* clipRect)

        {
            RECTANGLE clip;
            RECTANGLE local_20;

            if (clipRect == null)
            {
                clip = new RECTANGLE(-0x3fffffff, -0x3fffffff, 0x3fffffff, 0x3fffffff);
            }
            else
            {
                clip = *clipRect;
            }
            if ((UnkFlags & 2) != 0)
            {
                clip.CalculateIntersection(Bounds.ToPointer());
            }
            if ((UnkFlags & 1) == 0)
            {
                if (!clip.OneValidAndBothNotSame(ClipRect.ToPointer())) goto Finally;
                if ((UnkFlags & 1) == 0 && ClipRect.Value.Left == -0x3fffffff && ClipRect.Value.Top == -0x3fffffff && ClipRect.Value.Right == 0x3fffffff && ClipRect.Value.Bottom == 0x3fffffff)
                    goto DefaultClip;
            }

            IntPtr hrgn;
            if (Region.GetValue() == null)
            {
                hrgn = IntPtr.Zero;
                goto SelectHRGN;
            }
            var iVar2 = Region.GetValue().ThisCall(new IntPtr(0x00426380), new IntPtr(&local_20)).ToInt32();
            if (iVar2 == 0)
            {
                hrgn = Region.GetValue().ThisCall(new IntPtr(0x00427d10));
                if (hrgn != IntPtr.Zero)
                    goto SelectHRGN;
            }
            local_20.CalculateIntersection(&clip);
            PInvoke.Call(LibraryNames.GDI32, "SelectClipRgn", DC, IntPtr.Zero);
            PInvoke.Call(LibraryNames.GDI32, "IntersectClipRect", DC, new IntPtr(local_20.Left), new IntPtr(local_20.Top), new IntPtr(local_20.Right), new IntPtr(local_20.Bottom));
            goto From_DoClip;

        SelectHRGN:
            PInvoke.Call(LibraryNames.GDI32, "SelectClipRgn", DC, hrgn);
            goto DefaultClip;

        DefaultClip:
            if ((clip.Left != -0x3fffffff) || (clip.Top != -0x3fffffff) ||
                (clip.Right != 0x3fffffff) || (clip.Bottom != 0x3fffffff))
            {
                PInvoke.Call(LibraryNames.GDI32, "IntersectClipRect", DC, new IntPtr(clip.Left), new IntPtr(clip.Top), new IntPtr(clip.Right), new IntPtr(clip.Bottom));
            }
            goto From_DefaultClip;

        From_DefaultClip:
        From_DoClip:
            UnkFlags.Value &= unchecked((int)0xfffffffe);
            ClipRect.Value = clip;

        Finally:
            this.ThisCall(new IntPtr(0x0042a700));
            return;
        }

        [HookFunction(0x00422120, CallingConvention = CallingConvention.ThisCall)]
        private void SwapRegion(void** swap)
        {
            if ((OffsetX != 0) || (OffsetY != 0))
            {
                if (*swap != null)
                {
                    FromPointer<REGN>(new IntPtr(*swap)).Offset(-OffsetX, -OffsetY);
                }
                if (Region.GetValue() != null)
                {
                    Region.GetValue().Offset(OffsetX, OffsetY);
                }
            }
            UnmanagedFunctionCall.StdCall(new IntPtr(0x00419330), new IntPtr(Region.ToPointer()), new IntPtr(swap), new IntPtr(4)); // memswap
            UnkFlags.Value = UnkFlags | 1;
            return;
        }

        [HookFunction(0x00422180, CallingConvention = CallingConvention.ThisCall)]
        public void SetOffset(POINT* offset)
        {
            OffsetX.Value = offset->X;
            OffsetY.Value = offset->Y;
        }


        [HookFunction(0x004221A0, CallingConvention = CallingConvention.ThisCall)]
        public void GetOffset(POINT* dest)
        {
            dest->X = OffsetX.Value;
            dest->Y = OffsetY.Value;
        }

        //[HookFunction(FunctionNames.GPT__Method0042A700, CallingConvention = CallingConvention.ThisCall)]
        //public IntPtr Method0042A700()
        //{
        //    throw new NotImplementedException();
        //}

        [HookFunction(FunctionNames.GPT__FromWindow, CallingConvention = CallingConvention.StdCall)]
        public static GPT FromWindow(IntPtr hwnd)
        {
            IntPtr dc;
            GPT result = null;

            if (hwnd != default)
            {
                dc = PInvoke.Call(LibraryNames.USER32, "GetDC", hwnd);
                if (dc != default)
                {
                    result = FromHDC(dc);
                    if (result == null)
                    {
                        PInvoke.Call(LibraryNames.USER32, "ReleaseDC", hwnd, dc);
                    }
                    else
                    {
                        result.WindowHandle.Value = hwnd;
                    }
                }
            }
            else
            {
                // (**(code**)(*(int*)PTR_DAT_004e39a8 + 0x14))(10000);
                throw new NotImplementedException("Need to identify PTR_DAT_004e39a8");
            }
            return result;
        }

        [HookFunction(FunctionNames.GPT__FromHDC, CallingConvention = CallingConvention.StdCall)]
        public static GPT FromHDC(IntPtr dc)
        {
            GPT @this = null;

            if (dc != default)
            {
                var alloc = Program.Malloc(0x8c);
                if (alloc != default)
                {
                    Init(alloc);
                    Marshal.WriteInt32(alloc, 0x4df278);
                    @this = FromPointer<GPT>(alloc);
                    @this.Field_0x68.Value = 0;
                }
                if (@this != null)
                {
                    if (!@this.SetDC(dc))
                    {
                        @this.VirtualCall(0x10); // Free?
                        @this = null;
                    }
                }
            }
            return @this;
        }

        [HookFunction(FunctionNames.GPT__SetDC, CallingConvention = CallingConvention.ThisCall)]
        public bool SetDC(IntPtr dc)
        {
            IntPtr hdc;
            IntPtr h;

            DC.Value = dc;
            h = PInvoke.Call(LibraryNames.GDI32, "GetStockObject", new IntPtr(8));
            h = PInvoke.Call(LibraryNames.GDI32, "SelectObject", DC, h);
            if (h != default)
            {
                PInvoke.Call(LibraryNames.GDI32, "DeleteObject", h);
            }
            h = PInvoke.Call(LibraryNames.GDI32, "GetStockObject", IntPtr.Zero);
            h = PInvoke.Call(LibraryNames.GDI32, "SelectObject", DC, h);
            if (h != default)
            {
                PInvoke.Call(LibraryNames.GDI32, "DeleteObject", h);
            }
            h = PInvoke.Call(LibraryNames.GDI32, "GetStockObject", new IntPtr(0xd));
            h = PInvoke.Call(LibraryNames.GDI32, "SelectObject", DC, h);
            if (h != default)
            {
                PInvoke.Call(LibraryNames.GDI32, "DeleteObject", h);
            }
            Field_0x80.Value = 3;
            Field_0x84.Value = 4;
            hdc = DC;
            ClipRect.Value.Top = -0x3fffffff;
            ClipRect.Value.Left = -0x3fffffff;
            ClipRect.Value.Bottom = 0x3fffffff;
            ClipRect.Value.Right = 0x3fffffff;
            PInvoke.Call(LibraryNames.GDI32, "SelectClipRgn", hdc, IntPtr.Zero);
            PInvoke.Call(LibraryNames.GDI32, "SetPolyFillMode", DC, new IntPtr(2));
            return true;
        }
    }
}
