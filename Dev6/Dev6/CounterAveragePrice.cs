using System;
using System.Collections.Generic;
using System.Linq;

namespace Dev6
{
    /// <summary>
    /// Counts the average price of vehicles.
    /// </summary>
    public class CounterAveragePrice
    {
        /// <summary>
        /// Counts the average price of vehicles.
        /// </summary>
        /// <param name="listOfVehicles">
        /// The list of vehicles with their info.
        /// </param>
        /// <returns>
        /// The average price.
        /// </returns>
        public double CountAveragePrice(List<VehicleInfoStruct> listOfVehicles) => Math.Round((double)listOfVehicles.Sum(x => x.Price) / listOfVehicles.Count, 2);
    }
}