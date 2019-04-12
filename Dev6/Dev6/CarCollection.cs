using System.Collections.Generic;
using System.Linq;

namespace Dev6
{
    /// <summary>
    /// Provides methods to manipulation with collection
    /// </summary>
    class CarCollection
    {
        public IEnumerable<Car> Cars { get; set; }

        /// <summary>
        /// Constructor initializes fields
        /// </summary>
        /// <param name="cars">List of cars</param>
        public CarCollection(IEnumerable<Car> cars) => this.Cars = cars;

        /// <summary>
        /// Counts average price
        /// </summary>
        /// <returns>Average price</returns>
        public double GetAveragePrice() => this.Cars.Select(car => car.Price).Average();

        /// <summary>
        /// Counts average price of brand
        /// </summary>
        /// <param name="brand">Car brand</param>
        /// <returns>Average price of brand</returns>
        public double GetAveragePriceType(string brand)
        {
            brand = brand.ToLower();
            return this.Cars.Where(car => car.Brand == brand.ToLower()).Select(car => car.Price).Average();
        }

        /// <summary>
        /// Counts number of cars
        /// </summary>
        /// <returns>Number of cars</returns>
        public int GetCountAll() => this.Cars.Select(car => car.Count).Sum();

        /// <summary>
        /// Counts number of brands
        /// </summary>
        /// <returns>Number of brands</returns>
        public int GetCountTypes() => this.Cars.GroupBy(car => car.Brand).Count();
    }
}