using System;

namespace Open3dmm.Classes
{
    public class GOB : CMH
    {
        public int Field000C {
            get => GetField<int>(0x000C).Value;
            set => GetField<int>(0x000C).Value = value;
        }
        public Ref<GPT> GPT => GetReference<GPT>(0x0010);

        public RECTANGLE Rect {
            get => GetField<RECTANGLE>(0x0018).Value;
            set => GetField<RECTANGLE>(0x0018).Value = value;
        }

        public int Flags {
            get => GetField<int>(0x0058).Value;
            set => GetField<int>(0x0058).Value = value;
        }

        public Ref<GOB> Unk0058 => GetReference<GOB>(0x0058);
        public Ref<GOB> Unk0060 => GetReference<GOB>(0x0060);

        internal void Method004241B0(ref RECTANGLE _a4, int v2)
        {
            _a4 = this.Rect;
            Method004243A0(out var point, v2);
            _a4.Offset(point.X - Rect.Left, point.Y - Rect.Top);
        }

        public int Method004243A0(out POINT pt, int v2)
        {
            int result = 0;
            switch (v2 - 1)
            {
                default:
                    pt = POINT.Zero;
                    break;
                case 0:
                    pt = Rect.TopLeft;
                    break;
                case 1:
                    pt = POINT.Zero;
                    throw new NotImplementedException();
                case 2:
                case 3:
                    pt = POINT.Zero;
                    var gob = this;
                    while (gob != null && gob.Field000C == 0)
                    {
                        pt.X += gob.Rect.Left;
                        pt.Y += gob.Rect.Top;
                        gob = gob.Unk0058;
                    }

                    if (gob != null)
                        result = gob.Field000C;

                    if (v2 == 4 && result != 0)
                    {

                    }
                    break;
            }
            return result;
        }
    }
}
