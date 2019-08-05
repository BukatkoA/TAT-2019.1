namespace Dev4
{
    /// <summary>
    /// Class for laboratory lessons
    /// </summary>
    class LaboratoryClasses : Material
    {
        /// <summary>
        /// Performs deep entity cloning
        /// </summary>
        /// <returns>Clone of entity</returns>
        public override object Clone() => new LaboratoryClasses
        {
            UniqueIdentifier = UniqueIdentifier,
            Description = Description
        };
    }
}