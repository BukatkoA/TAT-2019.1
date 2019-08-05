using System;
using System.Collections.Generic;
using System.Linq;

namespace Dev3
{
    /// <summary>
    /// Optimization class by first criterion.
    /// </summary>
    class FirstCriteriaOptimize : Optimizer
    {
        private int InputAmount { get; set; }

        public FirstCriteriaOptimize(int inputAmount)
        {
            this.InputAmount = inputAmount;
        }

        /// <summary>
        /// Creates an optimized list of employees.
        /// </summary>
        /// <param name="listOfEmployees">List of employees</param>
        /// <returns>Optimized list of company employees</returns>
        public override List<Employee> Choose(List<Employee> listOfEmployees)
        {
            var sortedListOfEmployees = listOfEmployees.OrderBy(i => i.Value);
            var OptimizedEmployeeList = new List<Employee>();

            foreach (var employee in sortedListOfEmployees)
            {
                if (InputAmount >= employee.Salary)
                {
                    OptimizedEmployeeList.Add(employee);
                    InputAmount -= employee.Salary;
                }
            }

            if (OptimizedEmployeeList.Count == listOfEmployees.Count)
            {
                Console.WriteLine("Used by all employees of the company.");
            }

            if (OptimizedEmployeeList.Count == 0)
            {
                throw new Exception("Error. The input amount is too small.");
            }

            return OptimizedEmployeeList;
        }
    }
}