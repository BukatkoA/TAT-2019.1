using System.Collections.Generic;
using System.Xml.Linq;

namespace Dev6
{
    /// <summary>
    /// The trucks database.
    /// </summary>
    public class DatabaseTrucks
    {
        /// <summary>
        /// The instance of the Singleton-type class.
        /// </summary>
        private static DatabaseTrucks instance;

        /// <summary>
        /// Gets or sets the list of trucks.
        /// </summary>
        public List<VehicleInfoStruct> ListOfTrucks { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="DatabaseTrucks"/> class. 
        /// </summary>
        /// <param name="xDoc">
        /// XML doc with trucks info.
        /// </param>
        private DatabaseTrucks(XDocument xDoc)
        {
            this.ListOfTrucks = XmlParser.ParseVehicleInfo(xDoc);
        }

        /// <summary>
        /// Returns the instance of the class, or creates it if it doesn't exist
        /// </summary>
        /// <param name="xDoc">
        /// XML doc with trucks info.
        /// </param>
        /// <returns>
        /// The <see cref="DatabaseTrucks"/>.
        /// </returns>
        public static DatabaseTrucks GetDatabaseTrucks(XDocument xDoc) => instance ?? (instance = new DatabaseTrucks(xDoc));
    }
}