using System;

namespace ClassWork3
{
    /// <summary>
    /// Class for arbitrary triangles builders
    /// </summary>
    class NormalBuilder : TriangleBuilder
    {
        /// <summary>
        /// Constructor calls base constructor
        /// </summary>
        /// <param name="triangleBuilderSuccessor">New triangle builder</param>
        public NormalBuilder(TriangleBuilder triangleBuilderSuccessor) : base(triangleBuilderSuccessor) { }

        /// <summary>
        /// Builds a triangle using three points.
        /// Checks if this triangle is normal.
        /// </summary>
        /// <param name="firstPoint">First point of the triangle</param>
        /// <param name="secondPoint">Second point of the triangle</param>
        /// <param name="thirdPoint">Third point of the triangle</param>
        /// <returns>New normal triangle</returns>
        public override Triangle Build(Point firstPoint, Point secondPoint, Point thirdPoint)
        {
            if (!(Math.Abs(firstPoint.X - secondPoint.X) < epsilon && Math.Abs(firstPoint.X - thirdPoint.X) < epsilon) &&
                !(Math.Abs(firstPoint.Y - secondPoint.Y) < epsilon && Math.Abs(firstPoint.Y - thirdPoint.Y) < epsilon))
            {
                return new NormalTriangle(firstPoint, secondPoint, thirdPoint);
            }

            return Successor?.Build(firstPoint, secondPoint, thirdPoint) ?? throw new Exception("Can't build a normal triangle.");
        }
    }
}