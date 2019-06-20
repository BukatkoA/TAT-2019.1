using System;

namespace Dev2
{
    /// <summary>
    /// Contains entry point to the program.
    /// </summary>
    class EntryPoint
    {
        /// <summary>
        /// The entry point to the program.
        /// Calls conversion of method and
        /// Display the result.
        /// </summary>
        /// <param name="args">The command line arguments</param>
        static void Main(string[] args)
        {
            try
            {
                if (args.Length == 0)
                {
                    throw new Exception("The string contains no arguments.");
                }

                var converterWordToPhonemes = new ConverterToPhonemes();

                for (int i = 0; i < args.Length; i++)
                {
                    Console.WriteLine(args[i] + " -> " + converterWordToPhonemes.ConvertWordToPhonemes(args[i]));
                }
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Console.WriteLine($"Error: {ex.Message}.");
            }
            catch (NullReferenceException ex)
            {
                Console.WriteLine($"Error: {ex.Message}.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}