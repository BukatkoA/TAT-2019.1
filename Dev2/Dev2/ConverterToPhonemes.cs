using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dev2
{
    /// <summary>
    /// A class that converts words into phonemes.
    /// </summary>
    class ConverterToPhonemes
    {
        private StringBuilder workingString;

        /// <summary>
        /// Call the methods to validate the entered data. Reduce string to lowercase.
        /// </summary>
        /// <param name="input"></param>
        public ConverterToPhonemes(string[] input)
        {
            ValidationCheck validation = new ValidationCheck(input);
            validation.CheckValidation();
            validation.CheckStress();

            workingString = new StringBuilder();
            foreach (string word in input)
            {
                workingString.Append(word.ToLower()).Append(" ");
            }
            workingString.Remove(workingString.Length - 1, 1);
        }

        private readonly string Consonants = "бвгджзйлмнрпфктшсхцчщ";

        private readonly Dictionary<string, string> vowelAfterConsonant = new Dictionary<string, string>
        {
            ["ю"] = "у",
            ["я"] = "а",
            ["е"] = "э",
            ["ё"] = "о",
        };

        private readonly Dictionary<string, string> ringingAndDeafConverter = new Dictionary<string, string>
        {
            ["б"] = "п",
            ["в"] = "ф",
            ["г"] = "к",
            ["д"] = "т",
            ["ж"] = "ш",
            ["з"] = "с"
        };

        /// <summary>
        /// Main operating method. Here the word is replaced by transcription.
        /// </summary>
        /// <returns>Returns the processed string</returns>
        public StringBuilder Transcription()
        {

            for (int i = 0; i < workingString.Length - 1; i++)
            {
                if (workingString[i] == 'о' && workingString[i + 1] != '+')
                {
                    workingString.Replace('о', 'а', i, 1);
                }
            }
            workingString.Replace('о', 'а', workingString.Length - 1, 1);
            workingString.Replace("+", string.Empty);
            workingString.Replace('ь', '\'');

            foreach (KeyValuePair<string, string> keyValue in vowelAfterConsonant)
            {
                workingString.Replace(keyValue.Key, $"й{keyValue.Value}", 0, 1);
                for (int i = 1; i < workingString.Length; i++)
                {
                    if (Consonants.Contains(workingString[i - 1]))
                    {
                        workingString.Replace(keyValue.Key, $"'{keyValue.Value}", i, 1);
                    }
                    else
                    {
                        workingString.Replace(keyValue.Key, $"й{keyValue.Value}", i, 1);
                    }
                }
            }

            workingString.Replace("ъ", string.Empty);

            foreach (KeyValuePair<string, string> keyValue in ringingAndDeafConverter)
            {
                workingString.Replace($"{keyValue.Key} ", $"{keyValue.Value} ");
                workingString.Replace($"{keyValue.Key}' ", $"{keyValue.Value}' ");
                workingString.Replace(keyValue.Key, keyValue.Value, workingString.Length - 1, 1);
                workingString.Replace($"{keyValue.Key}'", $"{keyValue.Value}'", workingString.Length - 2, 2);

                if (ringingAndDeafConverter.ContainsValue(workingString[1].ToString()))
                {
                    workingString.Replace(keyValue.Key, keyValue.Value, 0, 1);
                }
                if (ringingAndDeafConverter.ContainsValue(workingString[2].ToString()))
                {
                    workingString.Replace($"{keyValue.Key}'", $"{keyValue.Value}'", 0, 2);
                }
                if (ringingAndDeafConverter.ContainsKey(workingString[1].ToString()))
                {
                    workingString.Replace(keyValue.Value, keyValue.Key, 0, 1);
                }
                if (ringingAndDeafConverter.ContainsKey(workingString[2].ToString()))
                {
                    workingString.Replace($"{keyValue.Value}'", $"{keyValue.Key}'", 0, 2);
                }

                for (int i = 1; i < workingString.Length - 1; i++)
                {
                    if (ringingAndDeafConverter.ContainsValue(workingString[i + 1].ToString()))
                    {
                        workingString.Replace(keyValue.Key, keyValue.Value, i, 1);
                        workingString.Replace($"{keyValue.Key}'", $"{keyValue.Value}'", i - 1, 2);
                    }
                }
                for (int i = 1; i < workingString.Length - 1; i++)
                {
                    if (ringingAndDeafConverter.ContainsKey(workingString[i + 1].ToString()))
                    {
                        workingString.Replace(keyValue.Value, keyValue.Key, i, 1);
                        workingString.Replace($"{keyValue.Value}'", $"{keyValue.Key}'", i - 1, 2);
                    }
                }
            }
            return workingString;
        }
    }
}
