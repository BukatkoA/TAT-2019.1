using System.Collections.Generic;

namespace Dev3
{
    /// <summary>
    /// Class for optimization
    /// The minimum cost at a fixed productivity
    /// </summary>
    class CriterionMinimumCost : CriterionMinimumStuff
    {
        /// <summary>
        /// Constructor calls base constructor
        /// </summary>
        /// <param name="productivity">Required productivity</param>
        public CriterionMinimumCost(int productivity) : base(productivity) { }

        /// <summary>
        /// Creates optimized list of employees
        /// According to the minimum cost at a fixed productivity
        /// Calls base method optimize
        /// </summary>
        /// <returns>Optimized list of employees</returns>
        public override List<Employee> Optimize()
        {
            this.EmployeeQualifications.Add(new Junior());
            return base.Optimize();
        }
    }
}