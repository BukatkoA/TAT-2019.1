using System.Collections.Generic;

namespace Dev4
{
    /// <summary>
    /// Class for seminars
    /// </summary>
    class SeminarClasses : Material
    {
        public List<string> Tasks { get; private set; }
        public List<string> Questions { get; private set; }
        public List<string> AnswersToTheQuestions { get; private set; }

        /// <summary>
        /// Constructor initializes fields
        /// </summary>
        public SeminarClasses()
        {
            this.Tasks = new List<string>() { "Find treasure", "Get 200 IQ" };
            this.Questions = new List<string>() { "2 + 2 = ?", "Stalin's birth year?" };
            this.AnswersToTheQuestions = new List<string>() { "4", "1878" };
        }

        /// <summary>
        /// Performs deep entity cloning
        /// </summary>
        /// <returns>Clone of entity</returns>
        public override object Clone()
        {
            var tasks = new List<string>();
            tasks.AddRange(this.Tasks);
            var questions = new List<string>();
            questions.AddRange(this.Questions);
            var answersToTheQuestions = new List<string>();
            answersToTheQuestions.AddRange(this.AnswersToTheQuestions);

            return new SeminarClasses
            {
                UniqueIdentifier = UniqueIdentifier,
                Description = Description,
                Tasks = tasks,
                Questions = questions,
                AnswersToTheQuestions = answersToTheQuestions
            };
        }
    }
}