using System;
using System.Collections.Generic;

namespace Dev3
{
    /// <summary>
    /// Abstract class for optimizers
    /// </summary>
    abstract class Optimizer
    {
        protected int CriterionParameter { get; set; }
        protected List<Employee> EmployeeQualifications { get; set; }
        protected List<Employee> NecessaryEmployees { get; set; }

        /// <summary>
        /// Constructor checks validity of input data
        /// And allocates memory
        /// </summary>
        /// <param name="criterionParameter">Sum or productivity</param>
        public Optimizer(int criterionParameter)
        {
            if (criterionParameter < 0)
            {
                throw new Exception("Value must be non-negative");
            }

            this.CriterionParameter = criterionParameter;
            this.EmployeeQualifications = new List<Employee>();
            this.NecessaryEmployees = new List<Employee>();
        }

        /// <summary>
        /// Abstract method for optimization
        /// </summary>
        /// <returns>Optimized list of employees</returns>
        public abstract List<Employee> Optimize();
    }
}