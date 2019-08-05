using System;
using System.Collections.Generic;

namespace Dev4
{
    /// <summary>
    /// Class for description set
    /// </summary>
    class DescriptionSetter
    {
        private readonly List<string> descriptions = new List<string>() { "boring", "interesting", "strange" };

        /// <summary>
        /// Generates random string description
        /// </summary>
        /// <returns>String description</returns>
        public string SetDescription()
        {
            var random = new Random();

            return $"Something {this.descriptions[random.Next(this.descriptions.Count)]}";
        }
    }
}