namespace Dev3
{
    class Senior : Middle
    {
        public Senior()
        {
            Salary = 900;
            Perfomance = 70;
            Value = (double)Perfomance / Salary;
        }
    }
}