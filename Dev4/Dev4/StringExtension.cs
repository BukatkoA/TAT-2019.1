using System;

namespace Dev4
{
    /// <summary>
    /// Class for string extensions
    /// </summary>
    static class StringExtension
    {
        /// <summary>
        /// Generates new GUID
        /// </summary>
        /// <param name="inputString">String calling the method</param>
        /// <returns>New GUID</returns>
        public static Guid SetGuid(this string inputString) => Guid.NewGuid();
    }
}