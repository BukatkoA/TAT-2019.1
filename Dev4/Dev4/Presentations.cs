using System;
using System.Collections.Generic;

namespace Dev4
{
    /// <summary>
    /// Class for presentations
    /// </summary>
    class Presentations
    {
        public string URI { get; private set; }
        public FormatPresentations Format { get; private set; }
        private readonly List<string> uris = new List<string>() { "maths", "physics", "English" };

        /// <summary>
        /// Constructor initializes fields
        /// </summary>
        public Presentations()
        {
            var random = new Random();
            this.URI = $"wikipedia.org/wiki/presentations/{this.uris[random.Next(this.uris.Count)]}";
            this.Format = (FormatPresentations)random.Next(Enum.GetNames(typeof(FormatPresentations)).Length);
        }

        /// <summary>
        /// Сopy constructor
        /// </summary>
        /// <param name="URI">URI</param>
        /// <param name="Format">Format</param>
        public Presentations(string URI, FormatPresentations Format)
        {
            this.URI = URI;
            this.Format = Format;
        }
    }
}