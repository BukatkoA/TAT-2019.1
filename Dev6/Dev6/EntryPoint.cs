using System;
using System.Xml.Linq;

namespace Dev6
{
    /// <summary>
    /// Get information about cars by parsing XML document.
    /// </summary>
    class EntryPoint
    {
        /// <summary>
        /// The entry point.
        /// </summary>
        /// <param name="args">
        /// Names of the XML documents to parse.
        /// </param>
        private static void Main(string[] args)
        {
            try
            {
                if (args.Length < 2)
                {
                    throw new ArgumentOutOfRangeException();
                }

                var xDocCars = XDocument.Load($"../../{args[0]}");
                var xDocTruck = XDocument.Load($"../../{args[1]}");
                var invoker = new CommandsInvoker(xDocCars, xDocTruck);
                invoker.InvokeCommands();
            }
            catch (ArgumentOutOfRangeException)
            {
                Console.WriteLine("2 arguments are required: XML doc name with cars info and XML doc name with trucks info");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}