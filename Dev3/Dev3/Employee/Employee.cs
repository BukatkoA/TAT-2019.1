namespace Dev3
{
    /// <summary>
    /// Abstract class for employees
    /// </summary>
    abstract class Employee
    {
        public int Salary { get; protected set; }
        public int Perfomance { get; protected set; }
        public double Value { get; protected set; }
    }
}