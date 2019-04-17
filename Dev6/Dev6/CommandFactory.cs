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
        public CommandFactory(List<CarCollection> carCollection)
        {
            this.Catalogs = carCollection;
        }

        /// <summary>
        /// Gets command
        /// </summary>
        public void GetCommand()
        {
            bool entry = true;
            InputTypes inputer = new InputTypes();

            while (entry)
            {
                switch (inputer.GetCommand())
                {
                    case CatalogCommands.CountTypes:
                        this.Command = new CountTypesCarsCommand(this.Catalogs[this.ChooseCarType()]);
                        break;
                    case CatalogCommands.CountAll:
                        this.Command = new CountAllCarsCommand(this.Catalogs[this.ChooseCarType()]);
                        break;
                    case CatalogCommands.AveragePrice:
                        this.Command = new AveragePriceCommand(this.Catalogs[this.ChooseCarType()]);
                        break;
                    case CatalogCommands.AveragePriceType:
                        Console.WriteLine("Enter car brand:");
                        this.Command = new AveragePriceTypesCommand(this.Catalogs[this.ChooseCarType()], Console.ReadLine());
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

                this.ExecuteCommands += this.Command.Execute;
            }

            this.ExecuteCommands?.Invoke();
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

                if (!int.TryParse(Console.ReadLine(), out carType) || carType > this.Catalogs.Count)
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