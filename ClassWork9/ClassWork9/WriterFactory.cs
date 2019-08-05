namespace ClassWork9
{
    /// <summary>
    /// The class chooses handler
    /// </summary>
    public class WriterFactory
    {
        const string jsonFormat = "json";
        const string xmlFormat = "xml";

        /// <summary>
        /// The method returns writer
        /// </summary>
        /// <param name="request">Request</param>
        /// <returns>Writer</returns>
        public IWriter GetWriter(string request)
        {
            int startIndex = request.IndexOf('.');
            int lastIndex = request.IndexOf(' ');
            string formatName = request.Substring(startIndex + 1, lastIndex - startIndex - 1);
            string fileName = request.Substring(0, lastIndex);

            switch (formatName)
            {
                case jsonFormat:
                    return new JsonFileHandler(fileName);
                case xmlFormat:
                    return new XmlFileHandler(fileName);
                default:
                    return null;
            }
        }
    }
}