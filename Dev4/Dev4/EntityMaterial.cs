using System;

namespace Dev4
{
    /// <summary>
    /// Base abstract class of Lectures, SeminarClasses and LaboratoryClasses.
    /// </summary>
    abstract class EntityMaterial : ICloneable
    {
        public Guid MyGuid { get; protected set; }
        public string Description { get; protected set; }

        /// <summary>
        /// Sets the GUID on the creation of an object
        /// </summary>
        public EntityMaterial()
        {
            SettingDescription description = new SettingDescription();
            Description = description.SetDescription();
            if (Description != null && Description.Length > 256)
            {
                throw new Exception("Error. The text of the description exceeds 256 symbols.");
            }
            MyGuid = Description.SetGuid();
        }

        /// <summary>
        /// Returns the description of the seminar classes
        /// </summary>
        /// <returns>Description</returns>
        public override string ToString()
        {
            return string.IsNullOrEmpty(Description) ? "No description" : $"Description: {Description}";
        }

        /// <summary>
        /// This method compares two objects.
        /// </summary>
        /// <param name="obj">Compared object</param>
        /// <returns>Comparison result</returns>
        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }
            EntityMaterial material = obj as EntityMaterial;
            if (material != null)
            {
                return (MyGuid == material.MyGuid);
            }
            return false;
        }

        /// <summary>
        /// Serves as the default hash function.
        /// </summary>
        /// <returns>A hash code for the current object</returns>
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        /// <summary>
        /// Abstract method performs deep entity cloning
        /// </summary>
        public abstract object Clone();
    }
}