using System;

namespace Dev3
{
    /// <summary>
    /// Contains entry point to the program
    /// Creates team according to choosen criterion
    /// </summary>
    class EntryPoint
    {
        /// <summary>
        /// Entry point to the program
        /// Creates criterion chooser, gets employees according to choosen criterion
        /// Displays necessary employees
        /// </summary>
        static void Main()
        {
            try
            {
                var criterionChooser = new CriterionChooser();
                var company = new Company();
                company.GetEmployees(criterionChooser.Choose());
                company.DisplayNecessaryEmployees();
                company.CheckForSufficiency();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}