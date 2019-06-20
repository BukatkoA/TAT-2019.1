using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dev2
{
    /// <summary>
    /// A class that converts words into phonemes.
    /// </summary>
    public class ConverterToPhonemes
    {
        public string Word { get; private set; }
        public int Stress { get; private set; }
        public List<Letter> ListOfLetters { get; private set; }
        public StringBuilder Phonemes { get; private set; }
        private readonly Dictionary<char, char> keysIsRingingValueIsDeaf = new Dictionary<char, char>
        {
            ['б'] = 'п',
            ['в'] = 'ф',
            ['г'] = 'к',
            ['д'] = 'т',
            ['ж'] = 'ш',
            ['з'] = 'с'
        };
        private readonly Dictionary<char, char> keysIsCompoundVowel = new Dictionary<char, char>
        {
            ['ю'] = 'у',
            ['я'] = 'а',
            ['ё'] = 'о',
            ['е'] = 'э'
        };

        /// <summary>
        /// Constructor for ConverToPhonemes.
        /// </summary>
        public ConverterToPhonemes()
        {
            this.ListOfLetters = new List<Letter>();
            this.Phonemes = new StringBuilder();
        }

        /// <summary>
        /// A method converts word to phonemes and return.
        /// </summary>
        /// <returns>Phonemes</returns>
        public StringBuilder ConvertWordToPhonemes(string word)
        {
            this.SetWord(word);
            this.ListOfLetters.Clear();
            this.Phonemes.Clear();
            this.DevideWordIntoLetters();

            foreach (var letter in this.ListOfLetters)
            {
                switch (letter.DefineTypeOfSymbol(letter.Current))
                {
                    case "vowel":
                        this.AddVowelToPhonemes(letter);
                        continue;
                    case "consonant":
                        this.AddConsonantToPhonemes(letter);
                        continue;
                    case "other":
                        this.Phonemes.Append(letter.Current == 'ь' ? "'" : "");
                        continue;
                }
            }

            return this.Phonemes;
        }

        /// <summary>
        /// Method sets parameter to this word and sets stress.
        /// </summary>
        /// <param name="word">Word</param>
        public void SetWord(string word)
        {
            word = word != null ? word.ToLower() : throw new NullReferenceException();
            int indexStress = 0;

            foreach (var i in word)
            {
                // If strecc of word more than 1 -> exception.
                if (((i >= 1072 && i <= 1103) || i == 'ё' || i == '+') && indexStress <= 1)
                {
                    indexStress += i == '+' ? 1 : 0;
                }
                else
                {
                    throw new ArgumentOutOfRangeException("letter", "Incorrected letter.");
                }
            }

            this.Stress = indexStress == 1 ? word.IndexOf('+') - 1 : -1;
            this.Word = indexStress == 1 ? word.Remove(word.IndexOf('+'), 1) : word;
        }

        /// <summary>
        /// This method adds objects to listOfLetters.
        /// </summary>
        public void DevideWordIntoLetters()
        {
            for (var index = 0; index < this.Word.Length; index++)
            {
                this.ListOfLetters.Add(new Letter
                {
                    Current = this.Word[index],
                    Previous = index != 0 ? this.Word[index - 1] : '\0',
                    Next = index < this.Word.Length - 2 ? this.Word[index + 1] : '\0',
                    Index = index
                });
            }
        }

        /// <summary>
        /// A method adds vowel to phonemes.
        /// </summary>
        /// <param name="letter">Letter</param>
        public void AddVowelToPhonemes(Letter letter)
        {
            if (letter == null)
            {
                throw new NullReferenceException("letter is null.");
            }

            // If the key is in compound vowel - true.
            if (this.keysIsCompoundVowel.ContainsKey(letter.Current))
            {
                // If previous letter is consonant - true(е->'е).
                // Add letter to phonemes.
                this.Phonemes.Append(
                    letter.DefineTypeOfSymbol(letter.Previous) == "consonant"
                    ? $"'{this.keysIsCompoundVowel[letter.Current]}"
                    : $"й{this.keysIsCompoundVowel[letter.Current]}");
            }
            else
            {
                this.AddOtherLetterToPhonemes(letter);
            }
        }

        /// <summary>
        /// A method adds consonant to phonemes.
        /// </summary>
        /// <param name="letter">Letter</param>
        public void AddConsonantToPhonemes(Letter letter)
        {
            if (letter == null)
            {
                throw new NullReferenceException("Letter is null.");
            }

            // Check on deaf. If first symbol is ringing, next symbol is deaf or consonant last and ringing, 
            // change the ringing to the deaf.
            if ((this.keysIsRingingValueIsDeaf.ContainsKey(letter.Current) && this.keysIsRingingValueIsDeaf.ContainsValue(letter.Next)) || (letter.Next == '\0' && this.keysIsRingingValueIsDeaf.ContainsKey(letter.Current)))
            {
                // Add deaf to phenemes. Get the value from the key.
                this.Phonemes.Append(this.keysIsRingingValueIsDeaf[letter.Current]);

                return;
            }
            // Check on ringing. If first symbol is deaf, next symbol is ringing
            // change the deaf to the ringing.
            else if (this.keysIsRingingValueIsDeaf.ContainsValue(letter.Current) && this.keysIsRingingValueIsDeaf.ContainsKey(letter.Next) && letter.Next != 'в')
            {
                // Add ringing to phenemes. Get the key from the value;
                this.Phonemes.Append(this.keysIsRingingValueIsDeaf.FirstOrDefault(x => x.Value == letter.Current).Key);

                return;
            }
            this.AddOtherLetterToPhonemes(letter);
        }

        /// <summary>
        /// A method defines the stress vawel or not and adds vawel in phonemes.
        /// </summary>
        /// <param name="letter">Symbol object</param>
        public void AddOtherLetterToPhonemes(Letter letter)
        {
            if (letter == null)
            {
                throw new NullReferenceException("Letter is null");
            }

            if ((letter.Current >= 1072 && letter.Current <= 1103) || letter.Current == 'ё')
            {
                this.Phonemes.Append(
                (letter.Current == 'о' && letter.Index != this.Stress)
                    ? 'а'
                    : letter.Current);
            }
            else
            {
                throw new ArgumentOutOfRangeException("The letter is not russian letter.");
            }
        }
    }
}