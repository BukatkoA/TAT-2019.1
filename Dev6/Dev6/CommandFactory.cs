using System;

namespace Dev6
{
    /// <summary>
    /// Class for creates commands
    /// </summary>
    class CommandFactory
    {
        public CarCollection Catalog { get; private set; }
        private ICommand Command { get; set; }

        /// <summary>
        /// Constructor initializes fields
        /// </summary>
        /// <param name="carCollection">Catalog of cars</param>
        public CommandFactory(CarCollection carCollection) => Catalog = carCollection;

        /// <summary>
        /// Declare an enumeration
        /// </summary>
        public enum CatalogCommand
        {
            CountTypes = 1,
            CountAll,
            AveragePrice,
            AveragePriceType,
            Exit
        }

        /// <summary>
        /// Gets command
        /// </summary>
        public void GetCommand()
        {
            for (bool entry = true; entry;)
            {
                Console.WriteLine("Enter command:\n" + "1. Count types\n" + "2. Count all\n"+ "3. Average price\n" + "4. Average price type\n" + "5. Exit");

                if (!int.TryParse(Console.ReadLine(), out int input))
                {
                    Console.WriteLine("Invalid input data");
                    continue;
                }

                switch ((CatalogCommand)input)
                {
                    case CatalogCommand.CountTypes:
                        Command = new CountTypesCarsCommand(Catalog);
                        break;

                    case CatalogCommand.CountAll:
                        Command = new CountAllCarsCommand(Catalog);
                        break;

                    case CatalogCommand.AveragePrice:
                        Command = new AveragePriceCommand(Catalog);
                        break;

                    case CatalogCommand.AveragePriceType:
                        Console.WriteLine("Enter car brand:");
                        Command = new AveragePriceTypesCommand(Catalog, Console.ReadLine());
                        break;

                    case CatalogCommand.Exit:
                        entry = false;
                        Command = null;
                        break;

                    default:
                        Console.WriteLine("Invalid command");
                        continue;
                }

                Command?.Execute();
            }
        }
    }
}