using System;

namespace ClassWork3
{
    class EquilateralTriangle : Triangle
    {
        /// <summary>
        /// Constructor calls base constructor
        /// </summary>
        /// <param name="firstPoint">First point of the triangle</param>
        /// <param name="secondPoint">Second point of the triangle</param>
        /// <param name="thirdPoint">Third point of the triangle</param>
        public EquilateralTriangle(Point firstPoint, Point secondPoint, Point thirdPoint) : base(firstPoint, secondPoint, thirdPoint) { }

        /// <summary>
        /// Get square of the triangle
        /// </summary>
        /// <returns>Square of the triangle</returns>
        public override double GetSquare() => FirstSide * FirstSide * Math.Sqrt(3) / 4;
    }
}