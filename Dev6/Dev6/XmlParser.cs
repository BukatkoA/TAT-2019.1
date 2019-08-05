using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace Dev6
{
    /// <summary>
    /// XML Parser for car information.
    /// </summary>
    public static class XmlParser
    {
        /// <summary>
        /// Parse info about cars from the XML doc to a list.
        /// </summary>
        /// <param name="xDoc">
        /// XML doc.
        /// </param>
        /// <returns>
        /// List of cars with their info.
        /// </returns>
        public static List<VehicleInfoStruct> ParseVehicleInfo(XDocument xDoc)
        {
            var listOfVehicles = from xe in xDoc.Element("cars").Elements("car")
                                 select new VehicleInfoStruct
                                 {
                                     Brand = xe.Element("brand").Value.ToLower(),
                                     Model = xe.Element("model").Value.ToLower(),
                                     Quantity = Convert.ToInt32(xe.Element("count").Value),
                                     Price = Convert.ToInt32(xe.Element("price").Value)
                                 };

            return listOfVehicles.ToList();
        }
    }
}