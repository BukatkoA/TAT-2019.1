using System;

namespace Dev2
{
    /// <summary>
    /// Calls all program methods and displays the result.
    /// </summary>
    class EntryPoint
    {
        /// <summary>
        /// The entry point to the program
        /// </summary>
        /// <param name="args">The command line arguments</param>
        static void Main(string[] args)
        {
            try
            {
                if (args.Length == 0)
                {
                    throw new Exception("Error. Please enter argument.");
                }
                ConverterToPhonemes converterToPhonemes = new ConverterToPhonemes(args[0]);
                Console.WriteLine(converterToPhonemes.ConvertToPhenomes());
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Console.WriteLine($"An exception: {ex.Message}.");
            }
            catch (NullReferenceException ex)
            {
                Console.WriteLine($"An exception: {ex.Message}.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An exception: {ex.Message}");
            }
        }
    }
}