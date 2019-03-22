namespace Dev3
{
    class Junior : Employee
    {
        public Junior()
        {
            Salary = 200;
            Perfomance = 10;
            Value = (double)Perfomance / Salary;
        }
    }
}
