using System;
using System.Linq;
using System.Text;

namespace Dev2
{
    class ValidationCheck
    {
        private StringBuilder stringCheck;

        /// <summary>
        /// This constructor validates the input arguments.
        /// </summary>
        /// <returns>Returns "true" if correct, if not "false"</returns>
        public bool CheckValidation()
        {
            if (stringCheck.Length == 0)
            {
                throw new Exception("Error. Please enter argument.");
            }
            return true;
        }

        /// <summary>
        /// The constructor creates a string from an array of strings.
        /// </summary>
        /// <param name="input"></param>
        public ValidationCheck(string[] input)
        {
            stringCheck = new StringBuilder();
            foreach (string word in input)
            {
                stringCheck.Append(word.ToLower()).Append(" ");
            }
            stringCheck.Remove(stringCheck.Length - 1, 1);
        }

        private readonly string vowels = "аиоуыэеёюя";
        int vowelsCount = 0;

        /// <summary>
        /// Checks string for correct accents
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        public bool CheckStress()
        { 
            int counterPlus = 0, counterYo = 0;

            for (int i = 0; i < stringCheck.Length; i++)
            {
                if (stringCheck[i] == '+')
                {
                    counterPlus += 1;
                }
                if (stringCheck[i] == 'ё')
                {
                    counterYo += 1;
                }
                if (vowels.Contains(stringCheck[i]))
                {
                    vowelsCount += 1;
                }
            }

            if (counterPlus > 1)
            {
                throw new Exception("Error. Entered more than two pluses.");
            }
            if (vowelsCount == 0)
            {
                throw new Exception("Error. There are no vowels in the word.");
            }
            if (stringCheck[0] == '+')
            {
                throw new Exception("Error. Incorrect plus position.");
            }
            if (counterPlus == 0 && counterYo == 0 && vowelsCount != 1)
            {
                throw new Exception("Error. There is no stress in the word.");
            }
            if (counterPlus == 1 && counterYo == 1)
            {
                throw new Exception("Error. Invalid input.");
            }

            return true;
        }
    }
}
