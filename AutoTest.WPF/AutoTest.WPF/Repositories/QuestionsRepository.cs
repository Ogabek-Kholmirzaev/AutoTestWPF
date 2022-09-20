using AutoTest.WPF.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AutoTest.WPF.Repositories
{
    public class QuestionsRepository
    {
        public int TicketQuestionsCount = 20;
        public List<QuestionEntity> Questions { get; set; }

        public QuestionsRepository()
        {
            LoadQuestionsFromJsonFile();
        }

        private void LoadQuestionsFromJsonFile()
        {
            try
            {
                var jsonStringData = File.ReadAllText("JsonData/uzlotin.json");
                Questions = JsonConvert.DeserializeObject<List<QuestionEntity>>(jsonStringData);
            }
            catch (Exception e)
            {
                Questions = new List<QuestionEntity>();
                throw;
            }
            
        }

        public int TicketsCount()
        {
            return Questions.Count / TicketQuestionsCount;
        }

        public List<QuestionEntity> GetQuestionsRange(int ticketIndex)
        {
            return Questions.Skip(ticketIndex * TicketQuestionsCount).Take(TicketQuestionsCount).ToList();
        }
    }
}