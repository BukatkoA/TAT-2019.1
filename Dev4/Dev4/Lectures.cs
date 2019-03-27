using System;
using System.Collections.Generic;

namespace Dev4
{
    /// <summary>
    /// This class stores text and presentation material.
    /// </summary>
    class Lectures : EntityMaterial
    {
        List<LaboratoryClasses> laboratory;
        List<SeminarClasses> seminars;
        Presentations presentations;
        private string lecturesText;

        /// <summary>
        /// The constructor sets the class description.
        /// </summary>
        public Lectures() : base()
        {
            description = "Lecture description";
            laboratory = null;
            seminars = null;
        }

        /// <summary>
        /// The constructor creates objects with all the information.
        /// </summary>
        /// <param name="IntroducedLaboratoryClasses">List with Laboratory Lesson</param>
        /// <param name="IntroducedSeminarClasses">List with Seminary Lesson</param>
        /// <param name="presentations">Presentation structure</param>
        public Lectures(List<LaboratoryClasses> IntroducedLaboratoryClasses, List<SeminarClasses> IntroducedSeminarClasses, Presentations presentations) : base()
        {
            if (IntroducedLaboratoryClasses != null)
            {
                laboratory = new List<LaboratoryClasses>();
                foreach (LaboratoryClasses laboratorys in IntroducedLaboratoryClasses)
                {
                    laboratory.Add((LaboratoryClasses)laboratorys.Clone());
                }
            }

            if (IntroducedSeminarClasses != null)
            {
                seminars = new List<SeminarClasses>();
                foreach (SeminarClasses seminar in IntroducedSeminarClasses)
                {
                    seminars.Add((SeminarClasses)seminar.Clone());
                }
            }
            this.presentations = presentations;
            description = "Lecture description";
        }

        /// <summary>
        /// This method returns the text of the lecture and checks it.
        /// </summary>
        public string LecturesText
        {
            get
            {
                if (string.IsNullOrEmpty(lecturesText))
                {
                    return "Lectures Text";
                }
                else return lecturesText;
            }
            set
            {
                if (value.Length <= 10000)
                {
                    lecturesText = value;
                }
                else
                {
                    throw new FormatException();
                } 
            }
        }

        // <summary>
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
            Lectures lecturesrr = new Lectures(laboratory, seminars, presentations);
            return lecturesrr;
        }
    }
}