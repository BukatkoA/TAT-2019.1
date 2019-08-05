using System;

namespace Dev3
{
    /// <summary>
    /// Class for choosing criterion
    /// </summary>
    class CriterionChooser
    {
        Optimizer optimizer;

        /// <summary>
        /// Chooses criterion according to input data
        /// </summary>
        /// <returns>Choosed criterion</returns>
        public Optimizer Choose()
        {
            Console.WriteLine("Select a criterion to calculate:\n1. Maximum productivity\n2. Minimum cost\n3. Minimum number of employees without juniors");

            if (!int.TryParse(Console.ReadLine(), out int choice))
            {
                throw new Exception("Incorrect input data");
            }

            switch (choice)
            {
                case 1:
                    Console.WriteLine("Enter the amount of money you have:");
                    this.optimizer = new CriterionMaximumProductivity(int.Parse(Console.ReadLine()));
                    break;
                case 2:
                    Console.WriteLine("Enter required productivity:");
                    this.optimizer = new CriterionMinimumCost(int.Parse(Console.ReadLine()));
                    break;
                case 3:
                    Console.WriteLine("Enter required productivity:");
                    this.optimizer = new CriterionMinimumStuff(int.Parse(Console.ReadLine()));
                    break;
                default:
                    throw new Exception("Incorrect input data");
            }

            return this.optimizer;
        }
    }
}