using System.Collections.Generic;

namespace Dev3
{
    abstract class Optimizer
    {
        public abstract List<Employee> Choose(List<Employee> listOfEmployees);
    }
}