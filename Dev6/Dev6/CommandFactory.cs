using System;
using System.Collections.Generic;

namespace Dev6
{
    /// <summary>
    /// Class for creates commands
    /// </summary>
    class CommandFactory
    {
        public List<CarCollection> Catalogs { get; private set; }
        private Action ExecuteCommands { get; set; }
        private ICommand Command { get; set; }

        /// <summary>
        /// Constructor initializes fields
        /// </summary>
        /// <param name="carCollection">Catalog of cars</param>
        public CommandFactory(List<CarCollection> carCollection) => this.Catalogs = carCollection;

        /// <summary>
        /// Gets command
        /// </summary>
        public void GetCommand()
        {
            for (bool entry = true; entry;)
            {
                Console.WriteLine("Enter command:\n" + "1. Count types\n" + "2. Count all\n" + "3. Average price\n" +
                    "4. Average price type\n" + "5. Execute\n" + "6. Exit");

                if (!int.TryParse(Console.ReadLine(), out int input))
                {
                    Console.WriteLine("Invalid input data");
                    continue;
                }

                switch ((CatalogCommands)input)
                {
                    case CatalogCommands.CountTypes:
                        this.Command = new CountTypesCarsCommand(Catalogs[ChooseCarType()]);
                        break;

                    case CatalogCommands.CountAll:
                        this.Command = new CountAllCarsCommand(Catalogs[ChooseCarType()]);
                        break;

                    case CatalogCommands.AveragePrice:
                        this.Command = new AveragePriceCommand(Catalogs[ChooseCarType()]);
                        break;

                    case CatalogCommands.AveragePriceType:
                        Console.WriteLine("Enter car brand:");
                        this.Command = new AveragePriceTypesCommand(Catalogs[ChooseCarType()], Console.ReadLine());
                        break;

                    case CatalogCommands.Execute:
                        entry = false;
                        this.Command = null;
                        continue;

                    case CatalogCommands.Exit:
                        entry = false;
                        this.Command = null;
                        this.ExecuteCommands = null;
                        continue;

                    default:
                        Console.WriteLine("Invalid command");
                        continue;
                }

                ExecuteCommands += Command.Execute;
            }

            ExecuteCommands?.Invoke();
        }

        /// <summary>
        /// Returns the type of car in accordance with the selected type of car
        /// </summary>
        /// <returns>Int type of car</returns>
        private int ChooseCarType()
        {
            int carType = 0;

            for (bool entry = true; entry;)
            {
                Console.WriteLine("Enter type of car:\n" + $"1. {CarTypes.Car}\n" + $"2. {CarTypes.Truck}");

                if (!int.TryParse(Console.ReadLine(), out carType) || carType > Catalogs.Count)
                {
                    Console.WriteLine("Invalid input data");
                    continue;
                }

                entry = false;
            }

            return --carType;
        }
    }
}