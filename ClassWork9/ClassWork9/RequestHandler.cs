using System;

namespace ClassWork9
{
    /// <summary>
    /// The class handles request
    /// </summary>
    public class RequestHandler
    {
        WriterFactory FactoryWriter { get; set; }
        FactoryDriverCreater FactoryDriverCreater { get; set; }

        public RequestHandler()
        {
            this.FactoryWriter = new WriterFactory();
            this.FactoryDriverCreater = new FactoryDriverCreater();
        }

        /// <summary>
        /// The method write data to file
        /// </summary>
        public void HandleRequests()
        {
            while (true)
            {
                Console.WriteLine("Enter the command in the format:\nFileName.format Browser");
                string request = Console.ReadLine();
                var creater = this.FactoryDriverCreater.GetDriver(request);
                var writer = this.FactoryWriter.GetWriter(request);

                if (creater != null && writer != null)
                {
                    var mainPage = new CurrencyPage(creater.Create());
                    writer.Write(mainPage.GetCurrency());
                    Console.WriteLine("Data written to file");

                    break;
                }
            }
        }
    }
}