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
        /// The constructor sets the class description.
        /// </summary>
        public Discipline()
        {
            SettingDescription description = new SettingDescription();
            Description = description.SetDescription();
            if (Description != null && Description.Length > 256)
            {
                throw new Exception("Too large description");
            }
            MyGuid = Description.SetGuid();
        }

        /// <summary>
        /// Indexator to receive a lecture on the index
        /// </summary>
        /// <param name="index">Inputed index</param>
        /// <returns>Lecture</returns>
        public Lectures this[int index]
        {
            get { return Lectures[index]; }
            set { Lectures[index] = value; }
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
            if (obj is Discipline discipline)
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
            if (IntroducedLectures != null)
            {
                Lectures = new List<Lectures>();

                foreach (Lectures lecture in IntroducedLectures)
                {
                    Lectures.Add((Lectures)lecture.Clone());
                }
            }

            return new Discipline
            {
                MyGuid = MyGuid,
                Description = Description,
                Lectures = Lectures,
            };
        }
    }
}