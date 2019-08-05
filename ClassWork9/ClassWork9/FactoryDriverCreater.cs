namespace ClassWork9
{
    /// <summary>
    /// The class chooses webdriver
    /// </summary>
    public class FactoryDriverCreater
    {
        const string chromeName = "Chrome";

        /// <summary>
        /// The method returns webdriver
        /// </summary>
        /// <param name="request">Request</param>
        /// <returns>Webdriver</returns>
        public ICreater GetDriver(string request)
        {
            int startIndex = request.IndexOf(' ');
            string driverName = request.Substring(startIndex + 1);

            switch (driverName)
            {
                case chromeName:
                    return new ChromeDriverCreater();
                default:
                    return null;
            }
        }
    }
}