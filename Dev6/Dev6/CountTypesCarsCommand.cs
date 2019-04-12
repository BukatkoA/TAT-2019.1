using System;

namespace Dev6
{
    /// <summary>
    /// Command that outputs count of brands to console
    /// </summary>
    class CountTypesCarsCommand : ICommand
    {
        private CarCollection Catalog { get; set; }

        /// <summary>
        /// Constructor initializes fields
        /// </summary>
        /// <param name="carCollection">Catalog of car</param>
        public CountTypesCarsCommand(CarCollection carCollection) => this.Catalog = carCollection;

        /// <summary>
        /// Executes command that outputs count of brands to console
        /// </summary>
        public void Execute() => Console.WriteLine("Total number of types: {0}", this.Catalog?.GetCountTypes());
    }
}