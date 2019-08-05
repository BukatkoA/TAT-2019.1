using System;

namespace Dev3
{
    /// <summary>
    /// Class with data about number of employees
    /// </summary>
    class Company
    {
        private readonly int _numberOfJuniors;
        private readonly int _numberOfMiddles;
        private readonly int _numberOfSeniors;
        private readonly int _numberOfLeads;
        private int[] _necessaryEmployees;

        /// <summary>
        /// Constructor initializes number of employees
        /// </summary>
        public Company()
        {
            this._numberOfJuniors = 15;
            this._numberOfMiddles = 9;
            this._numberOfSeniors = 7;
            this._numberOfLeads = 5;
        }

        /// <summary>
        /// Gets list of employees according to given criterion
        /// </summary>
        /// <param name="optimizer">Criterion</param>
        public void GetEmployees(Optimizer optimizer)
        {
            this._necessaryEmployees = new int[Enum.GetNames(typeof(Qualification)).Length];

            foreach (var employee in optimizer.Optimize())
            {
                switch (employee.GetType().Name)
                {
                    case "Lead":
                        this._necessaryEmployees[(int)Qualification.Lead]++;
                        break;
                    case "Senior":
                        this._necessaryEmployees[(int)Qualification.Senior]++;
                        break;
                    case "Middle":
                        this._necessaryEmployees[(int)Qualification.Middle]++;
                        break;
                    case "Junior":
                        this._necessaryEmployees[(int)Qualification.Junior]++;
                        break;
                }
            }
        }

        /// <summary>
        /// Checks for sufficiency of employees 
        /// </summary>
        public void CheckForSufficiency()
        {
            if (this._necessaryEmployees[(int)Qualification.Junior] > this._numberOfJuniors || this._necessaryEmployees[(int)Qualification.Middle] > this._numberOfMiddles
                || this._necessaryEmployees[(int)Qualification.Senior] > this._numberOfSeniors || this._necessaryEmployees[(int)Qualification.Lead] > this._numberOfLeads)
            {
                Console.WriteLine("The company can not provides so many employees");
            }
            else
            {
                Console.WriteLine("The company can provides the required number of employees");
            }
        }

        /// <summary>
        /// Displays optimized list of employees
        /// </summary>
        public void DisplayNecessaryEmployees()
        {
            Console.WriteLine("The number of employees you need:");
            Console.WriteLine($"Junior: {this._necessaryEmployees[(int)Qualification.Junior]}");
            Console.WriteLine($"Middle: {this._necessaryEmployees[(int)Qualification.Middle]}");
            Console.WriteLine($"Senior: {this._necessaryEmployees[(int)Qualification.Senior]}");
            Console.WriteLine($"Lead: {this._necessaryEmployees[(int)Qualification.Lead]}");
        }
    }
}