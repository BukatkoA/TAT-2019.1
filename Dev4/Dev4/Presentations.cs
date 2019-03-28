using System;
using System.Collections.Generic;

namespace Dev4
{
    /// <summary>
    /// Structure contains Url and format of presentation.
    /// </summary>
    class Presentations
    {
        public string Url { get; private set; }
        public FormatPresentations PresentationsFormat { get; private set; }
        private static List<string> uris = new List<string>() { "physics", "biology" };

        /// <summary>
        /// The constructor initializes the fields.
        /// </summary>
        public Presentations()
        {
            Random random = new Random();
            Url = $"canva.com/templates/presentations/{uris[random.Next(uris.Count)]}";
            PresentationsFormat = (FormatPresentations)random.Next(Enum.GetNames(typeof(FormatPresentations)).Length);
        }

        /// <summary>
        /// Сopy constructor
        /// </summary>
        /// <param name="Url">Url</param>
        /// <param name="Format">Format presentations</param>
        public Presentations(string Url, FormatPresentations Format)
        {
            this.Url = Url;
            PresentationsFormat = PresentationsFormat;
        }
    }
}