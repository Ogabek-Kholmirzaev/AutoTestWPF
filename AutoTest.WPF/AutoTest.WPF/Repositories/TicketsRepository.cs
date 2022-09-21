using System.Collections.Generic;
using System.IO;
using System.Linq;
using AutoTest.WPF.Models;
using Newtonsoft.Json;

namespace AutoTest.WPF.Repositories
{
    public class TicketsRepository
    {
        private const string Folder = "UserData";
        private const string FileName = "tikestslist.json";
        public List<Ticket> TicketsList = new List<Ticket>();

        public TicketsRepository()
        {
            ReadJsonData();
        }

        public void WriteToJson()
        {
            List<Ticket> ticketDataList =
                TicketsList.Select(t => new Ticket(t.Index, t.CorrectAnswersCount, t.QuestionsCount)).ToList();

            var jsonData = JsonConvert.SerializeObject(ticketDataList);

            if (!Directory.Exists(Folder))
            {
                Directory.CreateDirectory(Folder);
            }

            File.WriteAllText(Path.Combine(Folder, FileName), jsonData);
        }

        public void ReadJsonData()
        {
            if (File.Exists(Path.Combine(Folder, FileName)))
            {
                var jsonData = File.ReadAllText(Path.Combine(Folder, FileName));
                TicketsList = JsonConvert.DeserializeObject<List<Ticket>>(jsonData);
            }
        }
    }
}
