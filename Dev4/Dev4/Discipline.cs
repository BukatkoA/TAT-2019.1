using System;
using System.Collections.Generic;

namespace Dev4
{
    /// <summary>
    /// Class creates lectures for the discipline, clone discipline.
    /// </summary>
    class Discipline : ICloneable
    {
        private List<Lectures> lectures;
        private string description;
        protected Guid MyGuid;

        /// <summary>
        /// The constructor sets the class description.
        /// </summary>
        public Discipline()
        {
            MyGuid = Guid.NewGuid();
            description = "Discipline";
        }

        /// <summary>
        /// The constructor creates objects with all the information.
        /// </summary>
        /// <param name="IntroducedLectures"></param>
        /// <param name="MyGuid">GUID</param>
        /// <param name="description">Description</param>
        public Discipline(List<Lectures> IntroducedLectures, Guid MyGuid, string description)
        {
            if (IntroducedLectures != null)
            {
                lectures = new List<Lectures>();

                foreach (Lectures lecture in IntroducedLectures)
                {
                    lectures.Add((Lectures)lecture.Clone());
                }
            }

            this.MyGuid = MyGuid;
            this.description = description;
        }

        /// <summary>
        /// This constructor create object only with Lectures list.
        /// </summary>
        /// <param name="lectures">Lecture list</param>
        public Discipline(List<Lectures> lectures)
        {
            MyGuid = Guid.NewGuid();
            description = "Discipline";
            this.lectures = lectures;
        }

        /// <summary>
        /// Indexator to receive a lecture on the index
        /// </summary>
        /// <param name="index">Inputed index</param>
        /// <returns>Lecture</returns>
        public Lectures this[int index]
        {
            get { return lectures[index]; }
            set { lectures[index] = value; }
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
        /// Returns the description of the seminar classes
        /// </summary>
        /// <returns>Description</returns>
        public override string ToString()
        {
            return $"Description: {description}";
        }

        /// <summary>
        /// This method returns the object GUID
        /// </summary>
        /// <returns>GUID</returns>
        public Guid GuidDiscipline()
        {
            return MyGuid;
        }

        /// <summary>
        /// This method compares two objects.
        /// </summary>
        /// <param name="obj">Compared object</param>
        /// <returns>Comparison result</returns>
        public override bool Equals(Object obj)
        {
            if (obj is Discipline)
            {
                Discipline disciplineObject = (Discipline)obj;
                return this.GuidDiscipline() == disciplineObject.GuidDiscipline() ? true : false;
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

        /// <summary>
        /// Implemented interface method deeply copies object.
        /// </summary>
        /// <returns>The cloned object</returns>
        public object Clone()
        {
            Discipline discipline = new Discipline(lectures, MyGuid, description);
            return discipline;
        }
    }
}