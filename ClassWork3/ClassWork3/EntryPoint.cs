using System;

namespace ClassWork3
{
    /// <summary>
    /// Contains entry point to the program.
    /// Calculating square of the triangle
    /// </summary>
    class EntryPoint
    {
        /// <summary>
        /// Create a triangle by 3 point, get it's square.
        /// </summary>
        static void Main(string[] args)
        {
            try
            {
                TriangleBuilder triangleBuilder = new RightTriangleBuilder(new EquilateralTriangleBuilder(new NormalBuilder(null)));

                // Coordinates of a triangle in two-dimensional space
                Triangle triangle = triangleBuilder.Build(new Point(1.0, 1.0), new Point(1.0, 5.0), new Point(4.0, 1.0));
                Console.WriteLine($"The square of the triangle is {triangle?.GetSquare().ToString() ?? "Undefined"}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}