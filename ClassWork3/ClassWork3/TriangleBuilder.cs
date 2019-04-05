namespace ClassWork3
{
    /// <summary>
    /// Abstract class for triangle builders
    /// </summary>
    abstract class TriangleBuilder
    {
        /// <summary>
        /// The successor for chain of responsibility
        /// </summary>
        public TriangleBuilder Successor { get; private set; }

        /// <summary>
        /// Tolerance for float numbers comparison
        /// </summary>
        protected const double epsilon = 1E-6;

        /// <summary>
        /// Contructor initializes successor
        /// </summary>
        /// <param name="triangleBuilderSuccessor">The successor for chain of responsibility</param>
        public TriangleBuilder(TriangleBuilder triangleBuilderSuccessor)
        {
            Successor = triangleBuilderSuccessor;
        }

        /// <summary>
        /// Determines type of a triangle and creates it by provided points.
        /// </summary>
        /// <param name="firstPoint">First point of the triangle</param>
        /// <param name="secondPoint">Second point of the triangle</param>
        /// <param name="thirdPoint">Third point of the triangle</param>
        /// <returns>New triangle</returns>
        public abstract Triangle Build(Point firstPoint, Point secondPoint, Point thirdPoint);
    }
}