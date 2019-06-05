using System;

namespace Open3dmm
{
    [AttributeUsage(AttributeTargets.Property, Inherited = true, AllowMultiple = false)]
    public sealed class NativeFieldOffsetAttribute : Attribute
    {
        public NativeFieldOffsetAttribute(int offset)
        {
            FieldOffset = offset;
        }
        public int FieldOffset { get; }
    }
}
