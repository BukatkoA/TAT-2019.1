using System;

namespace ClassWork9
{
    /// <summary>
    /// Entry point to the program
    /// </summary>
    class EntryPoint
    {
        /// <summary>
        /// Entry point to the program
        /// Creates a class object and calls a method
        /// </summary>
        static void Main()
        {
            try
            {
                var requestHandler = new RequestHandler();
                requestHandler.HandleRequests();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}
