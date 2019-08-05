using System;
using System.Collections.Generic;

namespace Dev4
{
    /// <summary>
    /// Class for lectures
    /// </summary>
    class Lectures : Material
    {
        public string TextOfLecture { get; private set; }
        public Presentations LecturePresentation { get; private set; }
        public List<SeminarClasses> Seminars { get; private set; }
        public List<LaboratoryClasses> LaboratoryLessons { get; private set; }
        private readonly int _textOfLectureMaxLength = 100000;

        /// <summary>
        /// Constructor initializes fields
        /// </summary>
        public Lectures()
        {
            this.TextOfLecture = "Lecture";

            if (this.TextOfLecture != null && this.TextOfLecture.Length > this._textOfLectureMaxLength)
            {
                throw new Exception("Too large text of lecture");
            }

            this.LecturePresentation = new Presentations();
            this.Seminars = new List<SeminarClasses>() { new SeminarClasses(), new SeminarClasses() };
            this.LaboratoryLessons = new List<LaboratoryClasses>() { new LaboratoryClasses(), new LaboratoryClasses() };
        }

        /// <summary>
        /// Performs deep entity cloning
        /// </summary>
        /// <returns>Clone of entity</returns>
        public override object Clone()
        {
            var seminars = new List<SeminarClasses>();
            var laboratoryLessons = new List<LaboratoryClasses>();
            var presentation = new Presentations(this.LecturePresentation.URI, this.LecturePresentation.Format);

            foreach (var seminar in this.Seminars)
            {
                seminars.Add((SeminarClasses)seminar.Clone());
            }

            foreach (var laboratoryLesson in this.LaboratoryLessons)
            {
                laboratoryLessons.Add((LaboratoryClasses)laboratoryLesson.Clone());
            }

            return new Lectures
            {
                UniqueIdentifier = UniqueIdentifier,
                Description = Description,
                TextOfLecture = TextOfLecture,
                LecturePresentation = presentation,
                Seminars = seminars,
                LaboratoryLessons = laboratoryLessons
            };
        }
    }
}