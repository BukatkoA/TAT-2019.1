using System;

namespace Dev6
{
    /// <summary>
    /// Contains entry point to the program
    /// </summary>
    class EntryPoint
    {
        /// <summary>
        /// Entry point to the program
        /// Creates information about cars and command factory
        /// </summary>
        static void Main(string[] args)
        {
            try
            {
                if (args.Length == 0)
                {
                    throw new Exception("Error. Enter file name.");
                }

                CarGetter carGetter = new CarGetter(args[0]);
                CommandFactory commandFactory = new CommandFactory(new CarCollection(carGetter.GetCars()));
                commandFactory.GetCommand();
            }
            catch(Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}