using System;

namespace Dev2
{
    /// <summary>
    /// Calls all program methods and displays the result.
    /// </summary>
    class EntryPoint
    {
        static void Main(string[] args)
        {
            try
            {
                if (args.Length == 0)
                {
                    throw new Exception("Error. Please enter argument.");
                }
                ConverterToPhonemes converterToPhonemes = new ConverterToPhonemes(args);
                Console.WriteLine(converterToPhonemes.Transcription());

            }
            catch (Exception ex)
            {
                Console.WriteLine($"An exception: {ex.Message}");
                Console.WriteLine($"Method: {ex.TargetSite}");
                Console.WriteLine($"Stack trace: {ex.StackTrace}");
            }
        }
    }
}
