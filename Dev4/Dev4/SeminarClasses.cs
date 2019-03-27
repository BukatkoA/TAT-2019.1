using System.Collections.Generic;

namespace Dev4
{
    /// <summary>
    /// This class contains a set of tasks, a list of test questions and answers to them.
    /// </summary>
    class SeminarClasses : EntityMaterial
    {
        readonly List<string> Task;
        readonly Dictionary<string, string> QuestionAndAnswer;

        /// <summary>
        /// The constructor sets the class description.
        /// </summary>
        public SeminarClasses() : base()
        {
            Task = null;
            QuestionAndAnswer = null;
            description = "Seminar Classes description";
        }

        /// <summary>
        /// The constructor creates objects with all the information.
        /// </summary>
        /// <param name="Task">Task list</param>
        /// <param name="QuestionAndAnswer">Dictionary with quastion and answer</param>
        public SeminarClasses(List<string> Task, Dictionary<string, string> QuestionAndAnswer) : base()
        {
            this.Task.AddRange(Task);
            this.QuestionAndAnswer = QuestionAndAnswer;
            description = "Seminar Classes description";
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
        /// Implemented interface method deeply copies object.
        /// </summary>
        /// <returns>The cloned object</returns>
        public object Clone()
        {
            SeminarClasses seminarClasses = new SeminarClasses(Task, QuestionAndAnswer);
            return seminarClasses;
        }
    }
}