using System;
using System.Collections.Generic;

namespace Dev3
{
    class Company
    {
        const int juniorCount = 40; //The number of total Juniors in the company.
        const int middleCount = 30; //The number of total Middles in the company.
        const int seniorCount = 10; //The number of total Seniors in the company.
        const int teamleadCount = 5; //The number of total Team Leads in the company.

        private List<Employee> ListOfEmployees { get; set; } = new List<Employee>();

        public Company()
        {
            for (int i = 0; i < teamleadCount; i++)
            {
                ListOfEmployees.Add(new TeamLead());
            }

            for (int i = 0; i < seniorCount; i++)
            {
                ListOfEmployees.Add(new Senior());
            }

            for (int i = 0; i < middleCount; i++)
            {
                ListOfEmployees.Add(new Middle());
            }

            for (int i = 0; i < juniorCount; i++)
            {
                ListOfEmployees.Add(new Junior());
            }
        }

        public List<Employee> GetEmployees(Optimizer optimizer)
        {
            return optimizer.Choose(ListOfEmployees);
        }

        public static void ShowSortedList(List<Employee> OptimizedEmployeeList)
        {
            var employeesCounter = new int[4];
            foreach (var employee in OptimizedEmployeeList)
            { 
                if (employee is TeamLead)
                {
                    employeesCounter[3]++;
                    continue;
                }
                if (employee is Senior)
                {
                    employeesCounter[2]++;
                    continue;
                }
                if (employee is Middle)
                {
                    employeesCounter[1]++;
                    continue;
                }
                if (employee is Junior)
                {
                    employeesCounter[0]++;
                    continue;
                }
            }
            Console.WriteLine("The number of employees you'll need:");
            Console.WriteLine($"Junior: {employeesCounter[0]}\nMiddle: {employeesCounter[1]}\nSenior: {employeesCounter[2]}\nLead:   {employeesCounter[3]}");
        }
    }
}