using System;

namespace Dev3
{

    class EntryPoint
    {
       
        static void Main(string[] args)
        {
            try
            {
                var company = new Company();
                Optimizer optimizer;
                Console.WriteLine("Select a criterion to calculate:\n1. Maximum perfomance\n2. Minimum salary\n3. Minimum number of employees");
                int criterion = Int32.Parse(Console.ReadLine()); ;
                switch (criterion)
                {
                
                    case 1:
                        int InputAmount = Int32.Parse(Console.ReadLine());
                        optimizer = new FirstCriteriaOptimize(InputAmount);
                        break;
                    case 2:
                        int perfomance = Int32.Parse(Console.ReadLine());
                        optimizer = new SecondCriteriaOptimizer(perfomance);
                        break;
                    case 3:
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
                Console.WriteLine($"Method: {ex.TargetSite}");
                Console.WriteLine($"Stack trace: {ex.StackTrace}");
            }
        }
    }
}