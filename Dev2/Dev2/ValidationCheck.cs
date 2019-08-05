using System;
using System.Linq;

namespace Dev2
{
    /// <summary>
    /// Checks for correct data entry
    /// </summary>
    public class ValidationCheck
    {
        private string StringCheck { get; set; }

        /// <summary>
        /// The constructor creates a string from an array of strings.
        /// </summary>
        /// <param name="input">Input string</param>
        public ValidationCheck(string input)
        {
            this.StringCheck = input;
        }

        /// <summary>
        /// This method validates the input arguments.
        /// </summary>
        /// <returns>Returns "true" if correct, if not "false"</returns>
        public bool CheckValidation(string input)
        {
            this.StringCheck = (input ?? throw new NullReferenceException("String is null")).ToLower();

            return true;
        }

        /// <summary>
        /// Checks that letters are Cyrillic
        /// </summary>
        /// <returns>True if letters are Cyrillic, else throws exception</returns>
        public bool Check()
        {
            foreach (char i in this.StringCheck)
            {
                // Range(1072, 34) for Cyrillic letters
                if (i != '+' && !Enumerable.Range(1072, 34).Contains(i))
                {
                    throw new Exception("String contains non-Cyrillic symbols");
                }
            }

            return true;
        }

        private readonly string vowels = "аиоуыэеёюя";
        int vowelsCount = 0;

        /// <summary>
        /// Checks string for correct accents
        /// </summary>
        /// <returns>True if correct</returns>
        public bool CheckStress()
        {
            int counterPlus = 0, counterYo = 0;

            for (int i = 0; i < this.StringCheck.Length; i++)
            {
                if (this.StringCheck[i] == '+')
                {
                    counterPlus += 1;
                }
                else if (this.StringCheck[i] == 'ё')
                {
                    counterYo += 1;
                }
                else if (this.vowels.Contains(this.StringCheck[i]))
                {
                    this.vowelsCount += 1;
                }
            }

            if (counterPlus > 1)
            {
                throw new Exception("Error. Entered more than one pluses.");
            }
            else if (this.vowelsCount == 0)
            {
                throw new Exception("Error. There are no vowels in the word.");
            }
            else if (this.StringCheck[0] == '+')
            {
                throw new Exception("Error. Incorrect plus position.");
            }
            else if (counterPlus == 0 && counterYo == 0 && this.vowelsCount != 1)
            {
                throw new Exception("Error. There is no stress in the word.");
            }
            else if (counterPlus == 1 && counterYo == 1)
            {
                throw new Exception("Error. Invalid input.");
            }

            return true;
        }
    }
}