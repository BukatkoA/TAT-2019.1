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
        private StringBuilder WorkingString { get; set; }

        /// <summary>
        /// Call the methods to validate the entered data
        /// </summary>
        /// <param name="input">Input string</param>
        public ConverterToPhonemes(string input)
        {
            string lowerString = (input ?? throw new NullReferenceException("String is null")).ToLower();
            ValidationCheck validation = new ValidationCheck(lowerString);
            validation.CheckValidation(lowerString);
            validation.CheckStress();
            validation.Check();
            this.WorkingString = new StringBuilder(lowerString);
        }

        private readonly string VowelsString = "аиоуыэеёюя";
        private readonly string ConsonantsString = "бвгджзйлмнрпфктшсхцчщ";

        private readonly Dictionary<string, string> VowelAfterConsonant = new Dictionary<string, string>
        {
            ["ю"] = "у",
            ["я"] = "а",
            ["е"] = "э",
            ["ё"] = "о",
        };

        private readonly Dictionary<string, string> RingingAndDeafConverter = new Dictionary<string, string>
        {
            ["б"] = "п",
            ["в"] = "ф",
            ["г"] = "к",
            ["д"] = "т",
            ["ж"] = "ш",
            ["з"] = "с"
        };

        /// <summary>
        /// Calling conversion methods for converts to phonemes
        /// </summary>
        /// <returns>Converted working string</returns>
        public string ConvertToPhenomes()
        {
            this.VowelToPhonemes();
            this.OLetterToPhonemes();
            this.OtherSymbolsToPhonemes();
            this.RingingToPhonemes();
            this.DeafToPhonemes();

            return this.WorkingString.ToString();
        }

        /// <summary>
        /// Converts vowels to phonemes according to previous letter
        /// </summary>
        private void VowelToPhonemes()
        {
            foreach (KeyValuePair<string, string> keyValue in this.VowelAfterConsonant)
            {
                this.WorkingString.Replace(keyValue.Key, $"й{keyValue.Value}", 0, 1);

                for (int i = 1; i < this.WorkingString.Length; i++)
                {
                    if (this.ConsonantsString.Contains(this.WorkingString[i - 1]))
                    {
                        this.WorkingString.Replace(keyValue.Key, $"'{keyValue.Value}", i, 1);
                    }
                    else
                    {
                        this.WorkingString.Replace(keyValue.Key, $"й{keyValue.Value}", i, 1);
                    }
                }
            }
        }

        /// <summary>
        /// Converts letter 'о' to phonemes according to previous letter,
        /// Count of vowels and stress
        /// </summary>
        private void OLetterToPhonemes()
        {
            bool impactLetter = this.WorkingString.ToString().Contains("о+");
            int vowelsCount = 0;
            char lastVowel = new char();

            if (this.WorkingString[0] == 'о')
            {
                this.WorkingString.Replace('о', 'а', 0, 1);
                vowelsCount++;
                lastVowel = 'о';
            }

            for (int i = 1; i < this.WorkingString.Length; i++)
            {
                if (this.VowelsString.Contains(this.WorkingString[i]))
                {
                    vowelsCount++;
                    lastVowel = this.WorkingString[i];
                }

                if (this.WorkingString[i - 1] != 'й' && this.WorkingString[i - 1] != '\'')
                {
                    this.WorkingString.Replace('о', 'а', i, 1);
                }
            }

            if (vowelsCount == 1 && lastVowel == 'о')
            {
                this.WorkingString.Replace('а', 'о');
            }

            if (impactLetter)
            {
                this.WorkingString.Replace("а+", "о+");
            }
        }

        /// <summary>
        /// Converts '+', 'ь' and 'ъ' to phonemes
        /// </summary>
        private void OtherSymbolsToPhonemes()
        {
            this.WorkingString.Replace("+", string.Empty);
            this.WorkingString.Replace('ь', '\'');
            this.WorkingString.Replace("ъ", string.Empty);
        }

        /// <summary>
        /// Converts ringing consonants to phonemes according to their position
        /// On the end of word or before deaf letters
        /// </summary>
        private void RingingToPhonemes()
        {
            foreach (KeyValuePair<string, string> keyValue in this.RingingAndDeafConverter)
            {
                this.WorkingString.Replace(keyValue.Key, keyValue.Value, this.WorkingString.Length - 1, 1);
                this.WorkingString.Replace($"{keyValue.Key}'", $"{keyValue.Value}'", this.WorkingString.Length - 2, 2);

                if (this.RingingAndDeafConverter.ContainsValue(this.WorkingString[1].ToString()))
                {
                    this.WorkingString.Replace(keyValue.Key, keyValue.Value, 0, 1);
                }

                for (int i = 1; i < this.WorkingString.Length - 1; i++)
                {
                    if (this.RingingAndDeafConverter.ContainsValue(this.WorkingString[i + 1].ToString()))
                    {
                        this.WorkingString.Replace(keyValue.Key, keyValue.Value, i, 1);
                        this.WorkingString.Replace($"{keyValue.Key}'", $"{keyValue.Value}'", i - 1, 2);
                    }
                }
            }
        }

        /// <summary>
        /// Converts deaf consonants to phonemes according to their position
        /// Before ringing letters
        /// </summary>
        private void DeafToPhonemes()
        {
            foreach (KeyValuePair<string, string> keyValue in this.RingingAndDeafConverter)
            {
                if (this.RingingAndDeafConverter.ContainsKey(this.WorkingString[1].ToString()))
                {
                    this.WorkingString.Replace(keyValue.Value, keyValue.Key, 0, 1);
                }

                for (int i = 1; i < this.WorkingString.Length - 1; i++)
                {
                    if (this.RingingAndDeafConverter.ContainsKey(this.WorkingString[i + 1].ToString()))
                    {
                        this.WorkingString.Replace(keyValue.Value, keyValue.Key, i, 1);
                        this.WorkingString.Replace($"{keyValue.Value}'", $"{keyValue.Key}'", i - 1, 2);
                    }
                }
            }
        }
    }
}