using System;
using System.Collections.Generic;
using System.Xml.Linq;
using System.Linq;

namespace Dev6
{
    /// <summary>
    /// Parsing xml file
    /// </summary>
    class CarGetter
    {
        private static CarGetter _instance;
        private XDocument XmlDoc { get; set; }

        /// <summary>
        /// Constructor allocates memory
        /// </summary>
        private CarGetter() => this.XmlDoc = new XDocument();

        /// <summary>
        /// Singleton pattern
        /// Creates object if it doesn't exist
        /// </summary>
        /// <returns>CarGetter object</returns>
        public static CarGetter GetInstance()
        {
            if (_instance == null)
            {
                _instance = new CarGetter();
            }

            return _instance;
        }

        /// <summary>
        /// Loads xml file
        /// Gets cars from xml file
        /// </summary>
        /// <returns>List of cars</returns>
        public IEnumerable<Car> GetCars(string XmlFileName)
        {
            this.XmlDoc = XDocument.Load($"../../{XmlFileName}.xml");

            IEnumerable<Car> cars = this.XmlDoc.Element("cars").Elements("car").Select(xe => new Car
            (
                xe.Element("brand").Value,
                xe.Element("model").Value,
                int.TryParse(xe.Element("count").Value, out int count) ? count : throw new Exception("Incorrect count value"),
                int.TryParse(xe.Element("price").Value, out int price) ? price : throw new Exception("Incorrect price value")
             ));

            return cars;
        }
    }
}