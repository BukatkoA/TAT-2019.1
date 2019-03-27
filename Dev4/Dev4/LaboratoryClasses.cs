namespace Dev4
{
    /// <summary>
    /// Class Laboratory Classes.
    /// </summary>
    class LaboratoryClasses : EntityMaterial
    {
        /// <summary>
        /// The constructor sets the class description.
        /// </summary>
        public LaboratoryClasses() : base()
        {
            description = "Laboratory Classes description";
        }

        /// <summary>
        /// Returns the description of the seminar classes
        /// </summary>
        /// <returns>Description</returns>
        public override string ToString()
        {
            return $"Description: {description}";
        }

        /// <summary>
        /// Implemented interface method deeply copies object.
        /// </summary>
        /// <returns>The cloned object</returns>
        public object Clone()
        {
            LaboratoryClasses laboratoryClasses = new LaboratoryClasses();
            return laboratoryClasses;
        }
    }
}