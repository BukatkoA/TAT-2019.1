namespace Dev3
{
    /// <summary>
    /// Class for team lead type employee
    /// </summary>
    class TeamLead : Senior
    {
        public TeamLead()
        {
            Salary = 1500;
            Perfomance = 85;
            Value = (double)Perfomance / Salary;
        }
    }
}