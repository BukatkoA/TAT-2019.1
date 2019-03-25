using System;
using System.Text;
using System.Collections.Generic;

namespace Dev1
{
    class Finder
    {
        private StringBuilder workingString;

        /// <summary>
        /// SequenceCheck constructor checks for the correctness of the entered string.
        /// </summary>
        /// <param name="inputString">Array of strings</param>
        public Finder(string[] inputString)
        {
            workingString = new StringBuilder();

            foreach (string word in inputString)
            {
                workingString.Append(word);
            }

            if (workingString.Length < 2)
            {
                throw new FormatException();
            }
        }

        /// <summary>
        /// Compare the next symbol with the previous one and write 
        /// to the console if they are different.
        /// </summary>
        public List<string> CheckSequence()
        {
            StringBuilder sequence;
            List<string> sequences = new List<string>();

            for (int i = 0; i < workingString.Length - 1; i++)
            {
                sequence = new StringBuilder();
                sequence.Append(workingString[i]);

                for (int j = i + 1; j < workingString.Length; j++)
                {
                    if (workingString[j - 1] != workingString[j])
                    {
                        sequence.Append(workingString[j]);
                        sequences.Add(sequence.ToString());
                    }
                    else break;
                }
            }
            return sequences;
        }

        /// <summary>
        /// Display the sequence to the console.
        /// </summary>
        /// <param name="sequences">Final sequence</param>
        public void DisplaySequence(List<string> sequences)
        {
            if (sequences.Count == 0)
            {
                throw new FormatException();
            }
            else
            {
                foreach (string sequence in sequences)
                {
                    Console.WriteLine(sequence);
                }
            }
        }
    }
}