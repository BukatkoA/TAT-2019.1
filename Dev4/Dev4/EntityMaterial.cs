using System;

namespace Dev4
{
    /// <summary>
    /// Base abstract class of Lectures, SeminarClasses and LaboratoryClasses.
    /// </summary>
    abstract class EntityMaterial
    {
        protected Guid MyGuid;
        protected string description;

        /// <summary>
        /// Sets the GUID on the creation of an object
        /// </summary>
        public EntityMaterial()
        {
            MyGuid = Guid.NewGuid();
        }

        /// <summary>
        /// This method returns the object GUID
        /// </summary>
        /// <returns>GUID</returns>
        public Guid GetGuid()
        {
            return MyGuid;
        }

        /// <summary>
        /// This method adds a description to the object.
        /// </summary>
        /// <param name="inputDescription">Inputed description</param>
        public void SettingDescription(string inputDescription)
        {
            if (inputDescription.Length <= 256)
            {
                description = inputDescription;
            }
            else
            {
                throw new FormatException();
            }  
        }

        /// <summary>
        /// This method compares two objects.
        /// </summary>
        /// <param name="obj">Compared object</param>
        /// <returns>Comparison result</returns>
        public override bool Equals(Object obj)
        {
            if (obj is EntityMaterial)
            {
                EntityMaterial disciplineObject = (EntityMaterial)obj;
                return this.GetGuid() == disciplineObject.GetGuid() ? true : false;
            }
            else return false;
        }

        /// <summary>
        /// Serves as the default hash function.
        /// </summary>
        /// <returns>A hash code for the current object</returns>
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}