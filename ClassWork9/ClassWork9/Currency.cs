using System;
using System.Runtime.Serialization;

namespace ClassWork9
{
    /// <summary>
    /// The class has properties of currency
    /// </summary>
    [DataContract]
    [Serializable()]
    public class Currency
    {
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string Value { get; set; }

        /// <summary>
        /// Constructor of Currency
        /// </summary>
        /// <param name="name">Name of currency</param>
        /// <param name="value">Value of currency</param>
        public Currency(string name, string value)
        {
            this.Name = name;
            this.Value = value;
        }
    }
}