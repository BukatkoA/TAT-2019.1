using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Json;

namespace ClassWork9
{
    /// <summary>
    /// The class handles json file
    /// </summary>
    public class JsonFileHandler : IWriter
    {
        readonly string currenciesPath;

        /// <summary>
        /// Constructor of JsonFileHandler
        /// </summary>
        /// <param name=fileName">File name</param>
        public JsonFileHandler(string fileName)
        {
            this.currenciesPath = $"../../{fileName}";
        }

        /// <summary>
        /// The method writes data to json file
        /// </summary>
        public void Write(List<Currency> currencies)
        {
            DataContractJsonSerializer jsonFile;

            using (var fileStream = new FileStream(this.currenciesPath, FileMode.OpenOrCreate))
            {
                jsonFile = new DataContractJsonSerializer(typeof(List<Currency>));
                jsonFile.WriteObject(fileStream, currencies);
            }
        }
    }
}