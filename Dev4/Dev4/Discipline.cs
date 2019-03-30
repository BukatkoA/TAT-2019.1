using System;
using System.Collections.Generic;

namespace Dev4
{
    /// <summary>
    /// Class creates lectures for the discipline, clone discipline.
    /// </summary>
    class Discipline : ICloneable
    {
        public List<Lectures> Lectures { get; private set; }
        public Guid MyGuid { get; private set; }
        public string Description { get; private set; }

        /// <summary>
        /// Indexator to receive a lecture on the index
        /// </summary>
        /// <param name="index">Inputed index</param>
        /// <returns>Lecture</returns>
        public List<EntityMaterial> this[int index]
        {
            get
            {
                List<EntityMaterial> entityMaterials = new List<EntityMaterial>() { Lectures[index] };
                foreach (SeminarClasses seminar in Lectures[0].Seminars)
                {
                    entityMaterials.Add(seminar);
                }
                foreach (LaboratoryClasses laboratoryLesson in Lectures[0].Laboratory)
                {
                    entityMaterials.Add(laboratoryLesson);
                }
                return entityMaterials;
            }
        }

        /// <summary>
        /// The constructor sets the class description.
        /// </summary>
        public Discipline()
        {
            SettingDescription description = new SettingDescription();
            Description = description.SetDescription();
            if (Description != null && Description.Length > 256)
            {
                throw new Exception("Error. The text of the description exceeds 256 symbols.");
            }
            MyGuid = Description.SetGuid();
            Lectures = new List<Lectures>() { new Lectures(), new Lectures() };
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
            Discipline discipline = obj as Discipline;
            if (discipline != null)
            {
                return (MyGuid == discipline.MyGuid);
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
        /// Implemented interface method deeply copies object.
        /// </summary>
        /// <returns>The cloned object</returns>
        public object Clone()
        {
            List<Lectures> IntroducedLectures = new List<Lectures>();
            foreach (Lectures lecture in Lectures)
            {
                IntroducedLectures.Add((Lectures)lecture.Clone());
            }

            return new Discipline
            {
                MyGuid = MyGuid,
                Description = Description,
                Lectures = IntroducedLectures,
            };
        }
    }
}