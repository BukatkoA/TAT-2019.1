using System;
using System.Text;
using System.Collections.Generic;

namespace Dev1
{
    class FinderAndDisplayer
    {
        private StringBuilder workingString;

        /// <summary>
        /// SequenceCheck constructor checks for the correctness of the entered string.
        /// </summary>
        /// <param name="temporaryString"></param>

        public FinderAndDisplayer(StringBuilder temporaryString)
        {
            if (workingString.Length < 2)
            {
                throw new FormatException("String's length less than two symbols.");
            }
            else
            {
                workingString = temporaryString;
            }

        }

        /// <summary>
        /// The constructor creates a string from an array of strings.
        /// </summary>
        /// <param name="input">Array of strings</param>
        public FinderAndDisplayer(string[] input)
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

        public void DisplaySequence(List<string> sequences)
        {
            if (sequences.Count == 0)
            {
                Console.WriteLine("The sequence contains nothing.");
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
