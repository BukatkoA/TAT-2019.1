using System;
using System.Collections.Generic;
using System.Xml;

namespace Dev6
{
    /// <summary>
    /// Parsing xml file
    /// </summary>
    class CarGetter
    {
        private XmlDocument XmlDoc { get; set; }

        /// <summary>
        /// Constructor loads xml file
        /// </summary>
        /// <param name="xmlFile">Xml file name</param>
        public CarGetter(string xmlFile)
        {
            XmlDoc = new XmlDocument();
            XmlDoc.Load($"../../{xmlFile}.xml");
        }

        /// <summary>
        /// Gets cars from xml file
        /// </summary>
        /// <returns>List of cars</returns>
        public List<Car> GetCars()
        {
            var cars = new List<Car>();
            XmlElement xmlElement = XmlDoc.DocumentElement;

            foreach (XmlNode xmlNode in xmlElement)
            {
                string brand = string.Empty;
                string model = string.Empty;
                int count = 0;
                int price = 0;

                foreach (XmlNode childNode in xmlNode.ChildNodes)
                {
                    switch (childNode.Name)
                    {
                        case "brand":
                            brand = childNode.InnerText;
                            break;

                        case "model":
                            model = childNode.InnerText;
                            break;

                        case "count":
                            if (!int.TryParse(childNode.InnerText, out count))
                            {
                                throw new Exception("Invalid count value");
                            }
                            break;

                        case "price":
                            if (!int.TryParse(childNode.InnerText, out price))
                            {
                                throw new Exception("Invalid price value");
                            }
                            break;

                        default:
                            break;
                    }
                }

                cars.Add(new Car(brand, model, count, price));
            }

            return cars;
        }
    }
}