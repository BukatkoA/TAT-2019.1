using System;
using System.Collections.Generic;

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
                Lectures lectures = new Lectures();
                List<Lectures> listOfLectures = new List<Lectures> { lectures };
                Discipline discipline = new Discipline(listOfLectures);
                Discipline cloneDiscipline = (Discipline)discipline.Clone();
                discipline[0].SettingDescription("FirstDescription");

                if (discipline.Equals(discipline))
                {
                    Console.WriteLine("true");
                }
                
                if (discipline.Equals(cloneDiscipline))
                {
                    Console.WriteLine("true");
                }

                discipline.SettingDescription("SecondDescription");
                Console.WriteLine(discipline[0].ToString());
                Console.WriteLine(cloneDiscipline[0].ToString());
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