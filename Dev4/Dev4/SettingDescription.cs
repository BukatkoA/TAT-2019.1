using System;
using System.Collections.Generic;

namespace Dev4
{
    /// <summary>
    /// Sets the description
    /// </summary>
    class SettingDescription
    {
        private static List<string> descriptions = new List<string>() { "not interesting", "interesting", "cognitive" };

        /// <summary>
        /// Sets the random description
        /// </summary>
        /// <returns>Random description</returns>
        public string SetDescription()
        {
            Random random = new Random();
            return $"Something {descriptions[random.Next(descriptions.Count)]}";
        }
    }
}