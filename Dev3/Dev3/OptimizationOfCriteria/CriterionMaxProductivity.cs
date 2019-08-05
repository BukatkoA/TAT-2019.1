using System;
using System.Collections.Generic;
using System.Linq;

namespace Dev3
{
    /// <summary>
    /// Criterion 1: Maximum productivity within the sum
    /// </summary>
    class CriterionMaxProductivity : Optimizer
    {
        private int AvailableMoney { get; set; }

        public CriterionMaxProductivity(int availableMoney)
        {
            AvailableMoney = availableMoney;
        }

        /// <summary>
        /// Sorts employees by their valuation (product./salary), those with higher valuation go to the final list
        /// </summary>
        /// <param name="listOfEmployees">List of all employees</param>
        /// <returns>Compiled list of employees</returns>
        public override List<Employee> Choose(List<Employee> listOfEmployees)
        {
            var sortedListOfEmployees =
                listOfEmployees.OrderByDescending(i => i.Valuation).ToList(); //list sorted by employees valuation
            var listOfFoundEmployees = new List<Employee>();

            foreach (var employee in sortedListOfEmployees)
            {
                if (AvailableMoney >= employee.Salary)
                {
                    listOfFoundEmployees.Add(employee);
                    AvailableMoney -= employee.Salary;
                }
            }

            if (listOfFoundEmployees.Count == listOfEmployees.Count)
            {
                Console.WriteLine(
                    "Warning - all employees of the company are used");
            }

            if (listOfFoundEmployees.Count == 0)
            {
                throw new Exception("Entered money sum is too low");
            }

            return listOfFoundEmployees;
        }
    }
}