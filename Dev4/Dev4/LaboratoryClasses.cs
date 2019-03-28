namespace Dev4
{
    /// <summary>
    /// Class Laboratory Classes.
    /// </summary>
    class LaboratoryClasses : EntityMaterial
    {
        /// <summary>
        /// Implemented interface method deeply copies object.
        /// </summary>
        /// <returns>The cloned object</returns>
        public override object Clone()
        {
            return new LaboratoryClasses
            {
                MyGuid = MyGuid,
                Description = Description
            };
        }
    }
}