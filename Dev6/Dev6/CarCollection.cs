using System.Collections.Generic;
using System.Linq;

namespace Dev6
{
    /// <summary>
    /// Provides methods to manipulation with collection
    /// </summary>
    class CarCollection
    {
        private List<Car> Cars { get; set; }

        /// <summary>
        /// Constructor initializes fields
        /// </summary>
        /// <param name="cars">List of cars</param>
        public CarCollection(List<Car> cars) => Cars = cars;

        /// <summary>
        /// Counts average price
        /// </summary>
        /// <returns>Average price</returns>
        public double GetAveragePrice() => Cars.Average(car => car.Price);

        /// <summary>
        /// Counts average price of brand
        /// </summary>
        /// <param name="brand">Car brand</param>
        /// <returns>Average price of brand</returns>
        public double GetAveragePriceType(string brand)
        {
            brand = brand.ToLower();
            return Cars.Where(car => car.Brand.ToLower() == brand).Average(x => x.Price);
        }

        /// <summary>
        /// Counts number of cars
        /// </summary>
        /// <returns>Number of cars</returns>
        public int GetCountAll() => Cars.Sum(car => car.Count);

        /// <summary>
        /// Counts number of brands
        /// </summary>
        /// <returns>Number of brands</returns>
        public int GetCountTypes() => Cars.GroupBy(car => car.Brand).Count();
    }
}