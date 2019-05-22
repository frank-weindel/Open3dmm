using System;
using System.Runtime.InteropServices;

namespace Open3dmm.Classes
{
    public unsafe partial struct RECTANGLE
    {
        public int Left;
        public int Top;
        public int Right;
        public int Bottom;

        public POINT TopLeft {
            get => new POINT(Left, Top);
        }

        public POINT TopRight {
            get => new POINT(Right, Top);
        }

        public POINT BottomLeft {
            get => new POINT(Left, Bottom);
        }

        public POINT BottomRight {
            get => new POINT(Right, Bottom);
        }

        public int Width => Math.Abs(Right - Left);

        public int Height => Math.Abs(Bottom - Top);

        public static readonly RECTANGLE Empty = default;

        public RECTANGLE(int left, int top, int right, int bottom)
        {
            this.Left = left;
            this.Top = top;
            this.Right = right;
            this.Bottom = bottom;
        }

        public static short MinExtent => Marshal.ReadInt16(new IntPtr(0x4D5328));

        [HookFunction(FunctionNames.Rectangle_SizeLimit, CallingConvention = CallingConvention.ThisCall)]
        public RECTANGLE* SizeLimit(RECTANGLE* dest)
        {
            void limit(in int input, out int output)
            {
                output = 0x7fff;
                if (input < 0x8000)
                {
                    output = input;
                    if (input < MinExtent)
                        output = MinExtent;
                }
            }

            limit(in Left, out dest->Left);
            limit(in Top, out dest->Top);
            limit(in Right, out dest->Right);
            limit(in Bottom, out dest->Bottom);
            return dest;
        }

        [HookFunction(FunctionNames.Rectangle_CalculateIntersection, CallingConvention = CallingConvention.ThisCall)]
        public bool CalculateIntersection(RECTANGLE* other)
        {
            fixed (RECTANGLE* self = &this)
            {
                return CalculateIntersection(self, other);
            }
        }

        [HookFunction(FunctionNames.Rectangle_CalculateIntersectionBetween, CallingConvention = CallingConvention.ThisCall)]
        public bool CalculateIntersection(RECTANGLE* a, RECTANGLE* b)
        {
            Left = Math.Max(a->Left, b->Left);
            Right = Math.Min(a->Right, b->Right);
            Top = Math.Max(a->Top, b->Top);
            Bottom = Math.Min(a->Bottom, b->Bottom);

            if (Right >= Left
                && Bottom >= Top)
            {
                return true;
            }
            this = Empty;
            return false;
        }

        [HookFunction(FunctionNames.Rectangle_Copy, CallingConvention = CallingConvention.ThisCall)]
        public void Copy(RECTANGLE* source)
        {
            this = *source;
        }

        [HookFunction(FunctionNames.Rectangle_CopyAtOffset, CallingConvention = CallingConvention.ThisCall)]
        public void Copy(RECTANGLE* source, int offsetX, int offsetY)
        {
            Copy(source);
            Offset(offsetX, offsetY);
        }

        [HookFunction(FunctionNames.Rectangle_HitTest, CallingConvention = CallingConvention.ThisCall)]
        public bool HitTest(int x, int y)
        {
            if (Left > x || Right <= x)
                return false;
            if (Top > y || Bottom <= y)
                return false;
            return true;
        }

        [HookFunction(FunctionNames.Rectangle_Union, CallingConvention = CallingConvention.ThisCall)]
        public void Union(RECTANGLE* other)
        {
            if (other->Left < other->Right && other->Top < other->Bottom)
            {
                if (Left < Right && Top < Bottom)
                {
                    Left = Math.Min(Left, other->Left);
                    Top = Math.Min(Top, other->Top);
                    Right = Math.Max(Right, other->Right);
                    Bottom = Math.Max(Bottom, other->Bottom);
                }
                else
                {
                    Left = other->Left;
                    Top = other->Top;
                    Right = other->Right;
                    Bottom = other->Bottom;
                }
            }
        }

        [HookFunction(FunctionNames.Rectangle_TopLeftOrigin, CallingConvention = CallingConvention.ThisCall)]
        public void TopLeftOrigin()
        {
            Right -= Left;
            Bottom -= Top;
            Left = Top = 0;
        }

        [HookFunction(FunctionNames.Rectangle_Offset, CallingConvention = CallingConvention.ThisCall)]
        public void Offset(int offsetX, int offsetY)
        {
            Left += offsetX;
            Right += offsetX;
            Top += offsetY;
            Bottom += offsetY;
        }

        [HookFunction(FunctionNames.Rectangle_Transform, CallingConvention = CallingConvention.ThisCall)]
        public void Transform(RECTANGLE* from, RECTANGLE* to)
        {
            int toWidth;
            int toHeight;
            int fromWidth;
            int fromHeight;

            toWidth = to->Right - to->Left;
            fromWidth = from->Right - from->Left;
            if (toWidth == fromWidth)
            {
                this.Left += to->Left - from->Left;
                this.Right += to->Left - from->Left;
            }
            else
            {
                this.Left = ((this.Left - from->Left) * toWidth / fromWidth) + to->Left;
                this.Right = to->Left + ((this.Right - from->Left) * toWidth / fromWidth);
            }
            toHeight = to->Bottom - to->Top;
            fromHeight = from->Bottom - from->Top;
            if (toHeight == fromHeight)
            {
                this.Top += to->Top - from->Top;
                this.Bottom += to->Top - from->Top;
            }
            else
            {
                this.Top = ((this.Top - from->Top) * toHeight / fromHeight) + to->Top;
                this.Bottom = to->Top + ((this.Bottom - from->Top) * toHeight / fromHeight);
            }
        }

        [HookFunction(FunctionNames.Rectangle_OneValidAndBothNotSame, CallingConvention = CallingConvention.ThisCall)]
        public bool OneValidAndBothNotSame(RECTANGLE* other)
        {
            if (this.Top < this.Bottom)
            {
                if (this.Left < this.Right)
                {
                    return other->Left != this.Left || other->Top != this.Top || other->Right != this.Right || other->Bottom != this.Bottom;
                }
            }
            return (other->Top < other->Bottom) && other->Left < other->Right;
        }
    }
}
