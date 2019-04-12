using System;
using System.Collections.Generic;

namespace Dev6
{
    /// <summary>
    /// Contains entry point to the program
    /// </summary>
    class EntryPoint
    {
        /// <summary>
        /// Entry point to the program
        /// Creates getter for cars and trucks
        /// Creates command factory with list of car catalogs
        /// </summary>
        static void Main(string[] args)
        {
            try
            {
                // Check for 2 entered file names
                if (args.Length != 2)
                {
                    throw new Exception("Error. Enter file names.");
                }

                CarGetter carGetter = CarGetter.GetInstance();

                List<CarCollection> catalogs = new List<CarCollection>()
                {
                    new CarCollection(carGetter.GetCars(args[(int)CarTypes.Car])),
                    new CarCollection(carGetter.GetCars(args[(int)CarTypes.Truck]))
                };

                CommandFactory commandFactory = new CommandFactory(catalogs);
                commandFactory.GetCommand();
            }
            catch(Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}