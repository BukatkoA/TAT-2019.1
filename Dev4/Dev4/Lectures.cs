using System;
using System.Collections.Generic;

namespace Dev4
{
    /// <summary>
    /// This class stores text and presentation material.
    /// </summary>
    class Lectures : EntityMaterial
    {
        public List<LaboratoryClasses> Laboratory { get; private set; }
        public List<SeminarClasses> Seminars { get; private set; }
        public Presentations PresentationsLecture { get; private set; }
        public string LecturesText { get; private set; }

        /// <summary>
        /// The constructor initializes the fields.
        /// </summary>
        public Lectures()
        {
            LecturesText = "Lecture text";
            if (LecturesText != null && LecturesText.Length > 100000)
            {
                throw new Exception("Error. The text of the lecture exceeds 100,000 symbols.");
            }
            PresentationsLecture = new Presentations();
            Seminars = new List<SeminarClasses>() { new SeminarClasses(), new SeminarClasses() };
            Laboratory = new List<LaboratoryClasses>() { new LaboratoryClasses(), new LaboratoryClasses() };
        }

        /// <summary>
        /// Implemented interface method deeply copies object.
        /// </summary>
        /// <returns>The cloned objects</returns>
        public override object Clone()
        {
            List<SeminarClasses> seminars = new List<SeminarClasses>();
            foreach (var seminar in Seminars)
            {
                seminars.Add((SeminarClasses)seminar.Clone());
            }

            List<LaboratoryClasses> laboratoryLessons = new List<LaboratoryClasses>();
            foreach (LaboratoryClasses laboratoryLesson in Laboratory)
            {
                laboratoryLessons.Add((LaboratoryClasses)laboratoryLesson.Clone());
            }

            Presentations presentation = new Presentations(PresentationsLecture.Url, PresentationsLecture.PresentationsFormat);
            return new Lectures
            {
                MyGuid = MyGuid,
                Description = Description,
                LecturesText = LecturesText,
                PresentationsLecture = presentation,
                Seminars = seminars,
                Laboratory = laboratoryLessons
            };
        }
    }
}