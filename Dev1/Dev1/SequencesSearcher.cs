using System;
using System.Collections.Generic;
using System.Text;

namespace Dev1
{
    /// <summary>
    /// Finds and prints subsequences of non-repeating symbols.
    /// </summary>
    public class SequencesSearcher
    {
        private StringBuilder WorkingString { get; }

        /// <summary>
        /// SequenceCheck constructor checks for the correctness of the entered string.
        /// </summary>
        /// <param name="inputString">Array of strings</param>
        public SequencesSearcher(string[] inputString)
        {
            this.WorkingString = new StringBuilder();

            foreach (string word in inputString)
            {
                this.WorkingString.Append(word);
            }

            if (this.WorkingString.Length < 2)
            {
                throw new FormatException();
            }
        }

        /// <summary>
        /// Compare the next symbol with the previous one.
        /// </summary>
        /// <returns>Processed sequence</returns>
        public List<string> FindSequences()
        {
            StringBuilder sequence;
            var sequences = new List<string>();
            sequence = new StringBuilder();

            for (int i = 0; i < this.WorkingString.Length - 1; i++)
            {
                sequence.Clear();
                sequence.Append(this.WorkingString[i]);

                for (int j = i + 1; j < this.WorkingString.Length; j++)
                {
                    if (this.WorkingString[j - 1] != this.WorkingString[j])
                    {
                        sequence.Append(this.WorkingString[j]);
                        sequences.Add(sequence.ToString());
                    }
                    else
                    {
                        break;
                    }
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
                Console.WriteLine("Nothing found");
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