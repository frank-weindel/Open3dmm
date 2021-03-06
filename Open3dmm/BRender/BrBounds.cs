﻿using System.Collections.Generic;

namespace Open3dmm.BRender
{
    /// <summary>
    /// Axis aligned bounding box.
    /// </summary>
    public struct BrBounds
    {
        public BrBounds(BrVector3 min, BrVector3 max)
        {
            Minimum = min;
            Maximum = max;
        }

        /// <summary>
        /// Minimum corner of bounds.
        /// </summary>
        public BrVector3 Minimum { get; set; }
        /// <summary>
        /// Maximum corner of bounds.
        /// </summary>
        public BrVector3 Maximum { get; set; }

        public static BrBounds FromPoints(IEnumerable<BrVector3> points)
        {
            BrVector3 min = default;
            BrVector3 max = default;

            foreach (var p in points)
            {
                if (p.X < min.X)
                    min.X = p.X;
                if (p.Y < min.Y)
                    min.Y = p.Y;
                if (p.Z < min.Z)
                    min.Z = p.Z;
                if (p.X > max.X)
                    max.X = p.X;
                if (p.Y > max.Y)
                    max.Y = p.Y;
                if (p.Z > max.Z)
                    max.Z = p.Z;
            }

            return new BrBounds(min, max);
        }
    }
}
