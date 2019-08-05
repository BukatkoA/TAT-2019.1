namespace Dev3
{
    /// <summary>
    /// Abstract class for employees
    /// </summary>
    abstract class Employee
    {
        public int Salary { get; protected set; }
        public int Productivity { get; protected set; }
        public double Value => (double)this.Salary / this.Productivity;
    }
}