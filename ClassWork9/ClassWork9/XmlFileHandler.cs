using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace ClassWork9
{
    /// <summary>
    /// The method handles xml file
    /// </summary>
    public class XmlFileHandler : IWriter
    {
        readonly string currenciesPath;

        /// <summary>
        /// Constructor of XmlFileHandler
        /// </summary>
        /// <param name="fileName">File name</param>
        public XmlFileHandler(string fileName)
        {
            this.currenciesPath = $"../../{fileName}";
        }

        /// <summary>
        /// The method writes data to xml file
        /// </summary>
        public void Write(List<Currency> currencies)
        {
            XmlSerializer xmlFile;

            using (var fileStream = new FileStream(this.currenciesPath, FileMode.OpenOrCreate))
            {
                xmlFile = new XmlSerializer(typeof(List<Currency>));
                xmlFile.Serialize(fileStream, currencies);
            }
        }
    }
}