using System;

namespace Dev6
{
    /// <summary>
    /// Command that outputs average price to console
    /// </summary>
    class AveragePriceTypesCommand : ICommand
    {
        private CarCollection Catalog { get; set; }
        private string Brand { get; set; }

        /// <summary>
        /// Constructor initializes fields
        /// </summary>
        /// <param name="carCollection">Catalog of cars</param>
        /// <param name="brand">Brand for counting</param>
        public AveragePriceTypesCommand(CarCollection carCollection, string brand)
        {
            Catalog = carCollection;
            Brand = brand;
        }

        /// <summary>
        /// Executes command that outputs average price of brand to console
        /// </summary>
        public void Execute() => Console.WriteLine($"Average price {Brand} : {Catalog.GetAveragePriceType(Brand)}");
    }
}