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
                Discipline discipline = new Discipline();
                Console.WriteLine(discipline.ToString());
                Discipline disciplineClone = (Discipline)discipline.Clone();
                Console.WriteLine(discipline.Equals(disciplineClone) ? "Clone successful" : "Something wrong");
                Console.WriteLine(discipline[0][0] != disciplineClone[0][0] ? "Deep cloning" : "Surface cloning");
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