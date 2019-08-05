using System;
using System.Linq;

namespace Dev2
{
    /// <summary>
    /// Defines type of letter
    /// </summary>
    public class Letter
    {
        public char Previous { get; set; }
        public char Current { get; set; }
        public char Next { get; set; }
        public int Index { get; set; }
        readonly string consonants = "бвгджзйклмнпрстфхцчшщ";
        readonly string vowels = "аоиеёэыуюя";
        readonly string other = "ьъ\0";
        
        /// <summary>
        /// A method defines type of letter and return.
        /// </summary>
        /// <param name="letter">Letter</param>
        /// <returns>Type of letter</returns>
        public string DefineTypeOfSymbol(char letter)
        {
            if (this.vowels.Contains(letter))
            {
                return "vowel";
            }
            else if (this.consonants.Contains(letter))
            {
                return "consonant";
            }
            else if (this.other.Contains(letter))
            {
                return "other";
            }
            throw new ArgumentOutOfRangeException("letter", "Incorrected letter");
        }
    }
}