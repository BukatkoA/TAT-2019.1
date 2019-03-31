using System;

namespace Dev5
{
    /// <summary>
    /// Struct of point.
    /// </summary>
    public struct Point
    {
        public int CoordinateX { get; set; }
        public int CoordinateY { get; set; }
        public int CoordinateZ { get; set; }

        /// <summary>
        /// Constructor of point.
        /// </summary>
        /// <param name="x">Starting x coordinate</param>
        /// <param name="y">Starting y coordinate</param>
        /// <param name="z">Starting z coordinate</param>
        public Point(int x, int y, int z)
        {
            CoordinateX = x;
            CoordinateY = y;
            CoordinateZ = z;
        }

        /// <summary>
        /// Calculates the distance between two points
        /// </summary>
        /// <param name="anotherPoint">Another point to get distance</param>
        /// <returns>Distance between points</returns>
        public double GetDistanceToPoint(Point anotherPoint) =>
            Math.Sqrt(Math.Pow(anotherPoint.CoordinateX - CoordinateX, 2) +
                      Math.Pow(anotherPoint.CoordinateY - CoordinateY, 2) +
                      Math.Pow(anotherPoint.CoordinateZ - CoordinateZ, 2));
    }
}