using System;

namespace Dev6
{
    /// <summary>
    /// Command that outputs average price to console
    /// </summary>
    class AveragePriceCommand : ICommand
    {
        private CarCollection Catalog { get; set; }

        /// <summary>
        /// Constructor initializes fields
        /// </summary>
        /// <param name="carCollection">Catalog of cars</param>
        public AveragePriceCommand(CarCollection carCollection) => Catalog = carCollection;

        /// <summary>
        /// Executes command that outputs average price to console
        /// </summary>
        public void Execute() => Console.WriteLine("Average price: {0}", Catalog.GetAveragePrice());
    }
}