using System.Collections.Generic;

namespace AutoTest.WPF.Models
{
    public class Ticket
    {
        public int Index { get; set; }
        public int CorrectAnswersCount { get; set; }
        public List<QuestionEntity> Questions { get; set; }
        public List<int> SolvedQuestionsList;
        public int QuestionsCount
        {
            get
            {
                return Questions.Count;
            }
        }

        public Ticket(int index, List<QuestionEntity> questions)
        {
            Index = index;
            SolvedQuestionsList = new List<int>();
            Questions = questions;
        }
    }
}