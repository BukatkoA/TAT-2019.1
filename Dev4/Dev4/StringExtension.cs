using System;

namespace Dev4
{
    /// <summary>
    /// Class for string extension
    /// </summary>
    static class StringExtension
    {
        /// <summary>
        /// Sets the new Unique identificator
        /// </summary>
        /// <param name="inputString">Input string</param>
        /// <returns>New GUID</returns>
        public static Guid SetGuid(this string inputString)
        {
            return Guid.NewGuid();
        }
    }
}