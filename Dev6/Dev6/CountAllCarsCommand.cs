using System;

namespace Dev6
{
    /// <summary>
    /// Command that outputs count of cars to console
    /// </summary>
    class CountAllCarsCommand : ICommand
    {
        private CarCollection Catalog { get; set; }

        /// <summary>
        /// Constructor initializes fields
        /// </summary>
        /// <param name="carCollection">Catalog of car</param>
        public CountAllCarsCommand(CarCollection carCollection) => Catalog = carCollection;

        /// <summary>
        /// Executes command that outputs count of cars to console
        /// </summary>
        public void Execute() => Console.WriteLine("Total amount: {0}", Catalog.GetCountAll());
    }
}