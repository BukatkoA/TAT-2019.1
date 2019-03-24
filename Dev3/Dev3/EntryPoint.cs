using System;

namespace Dev3
{
    /// <summary>
    /// Calls all program methods and displays the result.
    /// </summary>
    class EntryPoint
    {
        /// <summary>
        /// Entry point in program
        /// </summary>
        /// <param name="args">The command line arguments</param>
        static void Main(string[] args)
        {
            try
            {
                var company = new Company();
                Optimizer optimizer;
                Console.WriteLine("Choose criteria to optimize employees:\n1. Maximum perfomance\n2. Minimum salary\n3. Minimum number of employees");
                int criterion = Int32.Parse(Console.ReadLine()); // Chooses criterion according to input data.
                switch (criterion)
                {
                    case 1:
                        Console.WriteLine("Enter the required amount: ");
                        int InputAmount = Int32.Parse(Console.ReadLine());
                        optimizer = new FirstCriteriaOptimize(InputAmount);
                        break;
                    case 2:
                        Console.WriteLine("Enter the required perfomance: ");
                        int perfomance = Int32.Parse(Console.ReadLine());
                        optimizer = new SecondCriteriaOptimizer(perfomance);
                        break;
                    case 3:
                        Console.WriteLine("Enter the required perfomance: ");
                        perfomance = Int32.Parse(Console.ReadLine());
                        optimizer = new ThirdCriteriaOptimize(perfomance);
                        break;
                    default:
                        throw new Exception("Error. Unknown criterion.");
                }
                var OptimizedEmployeeList = company.GetEmployees(optimizer); 
                Company.ShowSortedList(OptimizedEmployeeList);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An exception: {ex.Message}");
            }
        }
    }
}