using System;

namespace ClassWork3
{
    /// <summary>
    /// Struct for 2D point
    /// </summary>
    struct Point
    {
        /// <summary>
        /// Gets or sets the x coordinate.
        /// </summary>
        public double X { get; private set; }

        /// <summary>
        /// Gets or sets the y coordinate.
        /// </summary>
        public double Y { get; private set; }

        /// <summary>
        /// Constructor of point.
        /// </summary>
        /// <param name="x">X coordinate</param>
        /// <param name="y">Y coordinate</param>
        public Point(double x, double y)
        {
            X = x;
            Y = y;
        }

        /// <summary>
        /// Gets distance to another point
        /// </summary>
        /// <param name="point">Another point</param>
        /// <returns>Length of the side</returns>
        public double GetSide(Point anotherPoint) => Math.Sqrt(Math.Pow(anotherPoint.X - X, 2) + Math.Pow(anotherPoint.Y - Y, 2));
    }
}