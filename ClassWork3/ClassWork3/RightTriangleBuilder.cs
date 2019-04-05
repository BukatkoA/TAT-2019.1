using System;

namespace ClassWork3
{
    /// <summary>
    /// Class for right triangles builders
    /// </summary>
    class RightTriangleBuilder : TriangleBuilder
    {
        /// <summary>
        /// Constructor calls base constructor
        /// </summary>
        /// <param name="triangleBuilderSuccessor">New triangle builder</param>
        public RightTriangleBuilder(TriangleBuilder triangleBuilderSuccessor) : base(triangleBuilderSuccessor) { }

        /// <summary>
        /// Builds a triangle using three points.
        /// Checks if this triangle is equilateral.
        /// </summary>
        /// <param name="firstPoint">First point of the triangle</param>
        /// <param name="secondPoint">Second point of the triangle</param>
        /// <param name="thirdPoint">Third point of the triangle</param>
        /// <returns>New rectangle</returns>
        public override Triangle Build(Point firstPoint, Point secondPoint, Point thirdPoint)
        {
            Point vectorFirstToSecond = new Point(secondPoint.X - firstPoint.X, secondPoint.Y - firstPoint.Y);
            Point vectorFirstToThird = new Point(thirdPoint.X - firstPoint.X, thirdPoint.Y - firstPoint.Y);
            Point vectorSecondToThird = new Point(thirdPoint.X - secondPoint.X, thirdPoint.Y - secondPoint.Y);

            if (Math.Abs(vectorFirstToSecond.X * vectorFirstToThird.X + vectorFirstToSecond.Y * vectorFirstToThird.Y) < epsilon ||
                Math.Abs(vectorFirstToSecond.X * vectorSecondToThird.X + vectorFirstToSecond.Y * vectorSecondToThird.Y) < epsilon ||
                Math.Abs(vectorFirstToThird.X * vectorSecondToThird.X + vectorFirstToThird.Y * vectorSecondToThird.Y) < epsilon)
            {
                return new RightTriangle(firstPoint, secondPoint, thirdPoint);
            }

            return Successor?.Build(firstPoint, secondPoint, thirdPoint) ?? throw new Exception("Can't build a rectangle.");
        }
    }
}