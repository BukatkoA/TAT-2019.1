using System;
using System.Text;

namespace Dev1
{
    class SequenceCheck
    {
        StringBuilder workingString;

        /// <summary>
        /// The constructor creates a string from an array of strings.
        /// </summary>
        /// <param name="input">Array of strings</param>
        public SequenceCheck(string[] input)
        {
            workingString = new StringBuilder();

            foreach (string word in input)
            {
                workingString.Append(word + " ");
            }
            workingString.Remove(workingString.Length - 1, 1);
        }

        /// <summary>
        /// Compare the next symbol with the previous one and write 
        /// to the console if they are different.
        /// </summary>
        public void CheckSequence()
        {   
            for (int i = 0; i < workingString.Length - 1; i++)
            {
                StringBuilder sequence = new StringBuilder();
                sequence.Append(workingString[i]);

                for (int j = i + 1; j < workingString.Length; j++)
                {
                    if (workingString[j - 1] != workingString[j])
                    {
                        sequence.Append(workingString[j]);
                        Console.WriteLine(sequence);
                    }
                    else break;
                }
            }
        }
    }
}
