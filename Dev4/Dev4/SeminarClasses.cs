using System.Collections.Generic;

namespace Dev4
{
    /// <summary>
    /// This class contains a set of tasks, a list of test questions and answers to them.
    /// </summary>
    class SeminarClasses : EntityMaterial
    {
        public List<string> Task { get; private set; }
        public Dictionary<string, string> QuestionAndAnswer { get; private set; }

        /// <summary>
        /// The constructor initializes the fields.
        /// </summary>
        public SeminarClasses() : base()
        {
            Task = new List<string>() { "Multiply values", "Divide value" };
            QuestionAndAnswer = new Dictionary<string, string>()
            {
                { "2 * 2 = ?", "4" },
                { "6 / 2 = ?", "3" }
            };
        }

        /// <summary>
        /// Implemented interface method deeply copies object.
        /// </summary>
        /// <returns>The cloned object</returns>
        public override object Clone()
        {
            List<string> Task = new List<string>();
            this.Task.AddRange(Task);
            Dictionary<string, string> QuestionAndAnswer = new Dictionary<string, string>();
            this.QuestionAndAnswer = QuestionAndAnswer;

            return new SeminarClasses
            {
                MyGuid = MyGuid,
                Description = Description,
                Task = Task,
                QuestionAndAnswer = QuestionAndAnswer
            };
        }
    }
}