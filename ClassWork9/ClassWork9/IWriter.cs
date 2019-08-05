using System.Collections.Generic;

namespace ClassWork9
{
    /// <summary>
    /// Interface for factory pattern
    /// </summary>
    public interface IWriter
    {
        /// <summary>
        /// The method writes list to file
        /// </summary>
        /// <param name="currencies">Currencies</param>
        void Write(List<Currency> currencies);
    }
}
