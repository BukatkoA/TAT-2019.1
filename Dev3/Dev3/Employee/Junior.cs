namespace Dev3
{
    /// <summary>
    /// Class for junior type employee
    /// </summary>
    class Junior : Employee
    {
        public Junior()
        {
            Salary = 250;
            Perfomance = 10;
            Value = (double)Perfomance / Salary;
        }
    }
}