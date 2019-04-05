namespace ClassWork3
{
    /// <summary>
    /// Class for right triangles
    /// </summary>
    class RightTriangle : Triangle
    {
        /// <summary>
        /// Constructor calls base constructor
        /// </summary>
        /// <param name="firstPoint">First point of the triangle</param>
        /// <param name="secondPoint">Second point of the triangle</param>
        /// <param name="thirdPoint">Third point of the triangle</param>
        public RightTriangle(Point firstPoint, Point secondPoint, Point thirdPoint) : base(firstPoint, secondPoint, thirdPoint) { }

        /// <summary>
        /// Get square of the triangle
        /// </summary>
        /// <returns>Square of the triangle</returns>
        public override double GetSquare()
        {

            if (FirstSide < ThirdSide && SecondSide < ThirdSide)
            {
                return FirstSide * SecondSide / 2;
            }

            if (FirstSide < SecondSide && ThirdSide < SecondSide)
            {
                return FirstSide * ThirdSide / 2;
            }

            return SecondSide * ThirdSide / 2;
        }
    }
}