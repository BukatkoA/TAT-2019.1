using System;
using System.Collections.Generic;
using System.Linq;

namespace Dev3
{
    /// <summary>
    /// Criterion 2: Minimum cost for required productivity
    /// </summary>
    class CriterionMinCost : Optimizer
    {
        private int RequiredProductivity { get; set; }

        public CriterionMinCost(int requiredProductivity)
        {
            RequiredProductivity = requiredProductivity;
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
                if (RequiredProductivity >= employee.Productivity)
                {
                    listOfFoundEmployees.Add(employee);
                    RequiredProductivity -= employee.Productivity;
                }
            }

            if (listOfFoundEmployees.Count == listOfEmployees.Count)
            {
                Console.WriteLine(
                    "Warning - all employees of the company are used");
            }

            if (listOfFoundEmployees.Count == 0)
            {
                throw new Exception("Entered productivity is too low");
            }

            return listOfFoundEmployees;
        }
    }
}