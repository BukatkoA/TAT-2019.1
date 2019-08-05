using System.Collections.Generic;
using System.Xml.Linq;

namespace Dev6
{
    /// <summary>
    /// The cars database.
    /// </summary>
    public class DatabaseCars
    {
        /// <summary>
        /// The instance of the Singleton-type class.
        /// </summary>
        private static DatabaseCars instance;

        /// <summary>
        /// Gets or sets the list of cars.
        /// </summary>
        public List<VehicleInfoStruct> ListOfCars { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="DatabaseCars"/> class.
        /// </summary>
        /// <param name="xDoc">
        /// XML doc with cars info.
        /// </param>
        private DatabaseCars(XDocument xDoc)
        {
            this.ListOfCars = XmlParser.ParseVehicleInfo(xDoc);
        }

        /// <summary>
        /// Returns the instance of the class, or creates it if it doesn't exist
        /// </summary>
        /// <param name="xDoc">
        /// Name of XML doc with cars info.
        /// </param>
        /// <returns>
        /// The <see cref="DatabaseCars"/>.
        /// </returns>
        public static DatabaseCars GetDatabaseCars(XDocument xDoc) => instance ?? (instance = new DatabaseCars(xDoc));
    }
}