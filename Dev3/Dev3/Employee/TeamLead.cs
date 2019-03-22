namespace Dev3
{
    class TeamLead : Senior
    {
        public TeamLead()
        {
            Salary = 1200;
            Perfomance = 90;
            Value = (double)Perfomance / Salary;
        }
    }
}