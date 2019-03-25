using System;

namespace Dev1
{
    /// <summary>
    /// Class EntryPoint which realized SearchMethod.
    /// <param name="args">Arguments from command line</param>
    /// </summary>
    class EntryPoint
    {
        static void Main(string[] args)
        {
            try
            {
                if (args.Length == 0)
                {
                    throw new Exception("Please enter a argument.");
                }
                else if (args[0].Length < 2)
                {
                    throw new Exception("Please enter more than two symbols.");
                }
                else
                {
                    Finder sequencesFinder = new Finder(args);
                    sequencesFinder.DisplaySequence(sequencesFinder.CheckSequence());
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Error. Make sure to send a string with at least 2 characters.");
            }
            catch(Exception ex)
            {
                Console.WriteLine($"An exception: {ex.Message}");
            }
        }
    }
}