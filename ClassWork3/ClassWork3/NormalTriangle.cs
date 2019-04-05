using System;

namespace ClassWork3
{
    /// <summary>
    /// Class for normal triangles
    /// </summary>
    class NormalTriangle : Triangle
    {
        /// <summary>
        /// Constructor calls base constructor
        /// </summary>
        /// <param name="firstPoint">First point of the triangle</param>
        /// <param name="secondPoint">Second point of the triangle</param>
        /// <param name="thirdPoint">Third point of the triangle</param>
        public NormalTriangle(Point firstPoint, Point secondPoint, Point thirdPoint) : base(firstPoint, secondPoint, thirdPoint) { }

        /// <summary>
        /// Get square of the triangle
        /// </summary>
        /// <returns>Square of the triangle</returns>
        public override double GetSquare()
        {
            double semiPerimeter = (FirstSide + SecondSide + ThirdSide) / 2;

            return Math.Sqrt(semiPerimeter * (semiPerimeter - FirstSide) * (semiPerimeter - SecondSide) * (semiPerimeter - ThirdSide));
        }
    }
}