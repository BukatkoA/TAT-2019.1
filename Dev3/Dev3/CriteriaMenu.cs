using System;

namespace Dev3
{
    class CriteriaMenu
    {
        public Optimizer CriteriaChooser()
        {
            Optimizer optimizer;
            Console.WriteLine("Choose criteria to optimize employees:\n1. Maximum perfomance\n2. Minimum salary\n3. Minimum number of employees");
            // Chooses criterion according to input data
            int criterion = Int32.Parse(Console.ReadLine());
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
            return optimizer;
        }
    }
}