using System;

namespace ClassWork3
{
    /// <summary>
    /// Class for equilateral triangles builders
    /// </summary>
    class EquilateralTriangleBuilder : TriangleBuilder
    {
        /// <summary>
        /// Constructor calls base constructor
        /// </summary>
        /// <param name="triangleBuilderSuccessor">New triangle builder</param>
        public EquilateralTriangleBuilder(TriangleBuilder triangleBuilderSuccessor) : base(triangleBuilderSuccessor) { }

        /// <summary>
        /// Builds a triangle using three points.
        /// Checks if this triangle is equilateral.
        /// </summary>
        /// <param name="firstPoint">First point of the triangle</param>
        /// <param name="secondPoint">Second point of the triangle</param>
        /// <param name="thirdPoint">Third point of the triangle</param>
        /// <returns>New equilateral triangle</returns>
        public override Triangle Build(Point firstPoint, Point secondPoint, Point thirdPoint)
        {
            double firstSide = firstPoint.GetSide(secondPoint);
            double secondSide = firstPoint.GetSide(thirdPoint);
            double thirdSide = secondPoint.GetSide(thirdPoint);

            if (Math.Abs(firstSide - secondSide) < epsilon &&
                Math.Abs(firstSide - thirdSide) < epsilon &&
                Math.Abs(secondSide - thirdSide) < epsilon)
            {
                return new EquilateralTriangle(firstPoint, secondPoint, thirdPoint);
            }

            return Successor?.Build(firstPoint, secondPoint, thirdPoint) ?? throw new Exception("Can't build a equilateral triangle.");
        }
    }
}