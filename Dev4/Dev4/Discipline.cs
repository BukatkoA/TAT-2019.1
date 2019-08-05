using System;
using System.Collections.Generic;

namespace Dev4
{
    /// <summary>
    /// Class for disciplines
    /// </summary>
    class Discipline : ICloneable
    {
        public Guid UniqueIdentifier { get; private set; }
        public string Description { get; private set; }
        public List<Lectures> Lectures { get; private set; }
        private readonly int _descriptionMaxLength = 256;

        /// <summary>
        /// Indexer to get lectures and its materials
        /// </summary>
        /// <param name="i">Index of the lecture</param>
        /// <returns>List of lecture and its materials</returns>
        public List<Material> this[int i]
        {
            get
            {
                var materials = new List<Material>() { this.Lectures[i] };

                foreach (var seminar in this.Lectures[i].Seminars)
                {
                    materials.Add(seminar);
                }

                foreach (var laboratoryLesson in this.Lectures[i].LaboratoryLessons)
                {
                    materials.Add(laboratoryLesson);
                }

                return materials;
            }
        }

        /// <summary>
        /// Constructor initializes fields
        /// </summary>
        public Discipline()
        {
            var description = new DescriptionSetter();
            this.Description = description.SetDescription();

            if (this.Description != null && this.Description.Length > this._descriptionMaxLength)
            {
                throw new Exception("Too large description");
            }

            this.UniqueIdentifier = this.Description.SetGuid();
            this.Lectures = new List<Lectures>() { new Lectures(), new Lectures() };
        }

        /// <summary>
        /// Override method to return description of an entity
        /// </summary>
        /// <returns>Description of an entity</returns>
        public override string ToString() => string.IsNullOrEmpty(this.Description) ? "No description" : $"Description: {this.Description}";

        /// <summary>
        /// Override method for comparing entities
        /// </summary>
        /// <param name="obj">Entity for comparing</param>
        /// <returns>True if received entity has the same unique identifier</returns>
        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }

            if (obj is Discipline discipline)
            {
                return this.UniqueIdentifier == discipline.UniqueIdentifier;
            }

            return false;
        }

        /// <summary>
        /// Performs deep entity cloning
        /// </summary>
        /// <returns>Clone of entity</returns>
        public object Clone()
        {
            var lecturesCopy = new List<Lectures>();

            foreach (var lecture in this.Lectures)
            {
                lecturesCopy.Add((Lectures)lecture.Clone());
            }

            return new Discipline
            {
                UniqueIdentifier = UniqueIdentifier,
                Description = Description,
                Lectures = lecturesCopy,
            };
        }
    }
}