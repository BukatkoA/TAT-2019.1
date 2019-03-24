namespace Dev3
{
    /// <summary>
    /// Class for senior type employee.
    /// </summary>
    class Senior : Middle
    {
        public Senior()
        {
            Salary = 1000;
            Perfomance = 55;
            Value = (double)Perfomance / Salary;
        }
    }
}