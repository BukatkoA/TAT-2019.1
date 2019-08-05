using System;

namespace Dev5
{
    /// <summary>
    /// Struct for a 3D point
    /// </summary>
    struct Point
    {
        public int X { get; private set; }
        public int Y { get; private set; }
        public int Z { get; private set; }

        public Point(int x, int y, int z)
        {
            this.X = x;
            this.Y = y;
            this.Z = z;
        }

        /// <summary>
        /// Calculates distance between this point and another
        /// </summary>
        /// <param name="newPoint">Another point</param>
        /// <returns>Distance between points</returns>
        public double GetDistance(Point newPoint) => Math.Sqrt(Math.Pow(newPoint.X - this.X, 2) + Math.Pow(newPoint.Y - this.Y, 2) + Math.Pow(newPoint.Z - this.Z, 2));
    }
}