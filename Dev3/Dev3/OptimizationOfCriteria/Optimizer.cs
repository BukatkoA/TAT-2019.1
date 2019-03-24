using System.Collections.Generic;

namespace Dev3
{
    /// <summary>
    /// Abstract class for Choose method
    /// </summary>
    abstract class Optimizer
    {
        /// <summary>
        /// Abstract method for optimization
        /// </summary>
        /// <param name="listOfEmployees">List of employees</param>
        /// <returns>Optimized list of company employees</returns>
        public abstract List<Employee> Choose(List<Employee> listOfEmployees);
    }
}