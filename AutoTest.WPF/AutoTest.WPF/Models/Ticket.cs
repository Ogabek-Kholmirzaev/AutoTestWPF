using System.Collections.Generic;

namespace AutoTest.WPF.Models
{
    public class Ticket
    {
        public int Index { get; set; }
        public int CorrectAnswersCount { get; set; }
        public List<QuestionEntity> Questions { get; set; }
        public Dictionary<int, int> SolvedQuestionsDictionary { get; set; }
        public int QuestionsCount { get; set; }

        public Ticket()
        {

        }

        public Ticket(int index, List<QuestionEntity> questions)
        {
            Index = index;
            SolvedQuestionsDictionary = new Dictionary<int, int>();
            Questions = questions;
            QuestionsCount = questions.Count;
        }

        public Ticket(int index, int correctAnswersCount, int questionsCount)
        {
            Index = index;
            CorrectAnswersCount = correctAnswersCount;
            QuestionsCount = questionsCount;
        }
    }
}