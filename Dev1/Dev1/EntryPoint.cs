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
                    FinderAndDisplayer sequencesFinder = new FinderAndDisplayer(args);
                    sequencesFinder.DisplaySequence(sequencesFinder.CheckSequence());

                }
            }
            catch(Exception ex)
            {
                Console.WriteLine($"Исключение: {ex.Message}");
                Console.WriteLine($"Метод: {ex.TargetSite}");
                Console.WriteLine($"Трассировка стека: {ex.StackTrace}");
            }
        }
    }
}
