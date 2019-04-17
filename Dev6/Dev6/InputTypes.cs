using System;

namespace Dev6
{
    /// <summary>
    /// Class for inputting data
    /// </summary>
    class InputTypes
    {
        /// <summary>
        /// Returns the selected command according to input data
        /// </summary>
        /// <returns>Selected command</returns>
        public CatalogCommands GetCommand()
        {
            Console.WriteLine("Enter command:\n" + "1. Count types\n" + "2. Count all\n" + "3. Average price\n"
                + "4. Average price type\n" + "5. Execute\n" + "6. Exit");

            if (!int.TryParse(Console.ReadLine(), out int input))
            {
                throw new Exception("Invalid input data");
            }

            return (CatalogCommands)input;
        }
    }
}