namespace ClassWork3
{
    /// <summary>
    /// Abstract class for triangles
    /// </summary>
    abstract class Triangle
    {
        public Point FirstPoint { get; private set; }
        public Point SecondPoint { get; private set; }
        public Point ThirdPoint { get; private set; }

        /// <summary>
        /// The length of FirstSide line
        /// </summary>
        public double FirstSide => FirstPoint.GetSide(SecondPoint);

        /// <summary>
        /// The length of SecondSide line
        /// </summary>
        public double SecondSide => FirstPoint.GetSide(ThirdPoint);

        /// <summary>
        /// The length of ThirdSide line
        /// </summary>
        public double ThirdSide => SecondPoint.GetSide(ThirdPoint);

        /// <summary>
        /// Constructor initializes points of the triangle
        /// </summary>
        /// <param name="firstPoint">First point of the triangle</param>
        /// <param name="secondPoint">Second point of the triangle</param>
        /// <param name="thirdPoint">Third point of the triangle</param>
        public Triangle(Point firstPoint, Point secondPoint, Point thirdPoint)
        {
            FirstPoint = firstPoint;
            SecondPoint = secondPoint;
            ThirdPoint = thirdPoint;
        }

        /// <summary>
        /// Get square of the triangle
        /// </summary>
        /// <returns>Square of the triangle</returns>
        public abstract double GetSquare();
    }
}