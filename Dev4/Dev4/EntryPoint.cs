using System;

namespace Dev4
{
    /// <summary>
    /// Calls all program methods and displays the result.
    /// </summary>
    class EntryPoint
    {
        /// <summary>
        /// Entry point in program
        /// </summary>
        /// <param name="args">The command line arguments</param>
        static void Main(string[] args)
        {
            try
            {
                Lectures lecture = new Lectures();
                Console.WriteLine(lecture.PresentationsLecture.Url);
            }
            catch (FormatException)
            {
                Console.WriteLine("Error. Invalid input format.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An exception: {ex.Message}");
            }
        }
    }
}