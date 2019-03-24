namespace Dev3
{
    /// <summary>
    /// Class for middle type employee
    /// </summary>
    class Middle : Junior
    {
        public Middle()
        {
            Salary = 500;
            Perfomance = 25;
            Value = (double)Perfomance / Salary;
        }
    }
}