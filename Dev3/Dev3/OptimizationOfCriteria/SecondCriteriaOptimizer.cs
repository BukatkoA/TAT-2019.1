using System;
using System.Collections.Generic;
using System.Linq;

namespace Dev3
{
    /// <summary>
    /// Optimization class by second criterion.
    /// </summary>
    class SecondCriteriaOptimizer : Optimizer
    {
        private int Perfomance { get; set; }

        public SecondCriteriaOptimizer(int perfomance)
        {
            this.Perfomance = perfomance;
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
                if (Perfomance >= employee.Perfomance)
                {
                    OptimizedEmployeeList.Add(employee);
                    Perfomance -= employee.Perfomance;
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