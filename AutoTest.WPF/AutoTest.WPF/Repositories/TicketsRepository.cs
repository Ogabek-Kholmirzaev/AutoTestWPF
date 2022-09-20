using System.Collections.Generic;
using AutoTest.WPF.Models;

namespace AutoTest.WPF.Repositories
{
    public class TicketsRepository
    {
        public List<Ticket> TicketsList { get; set; }

        public TicketsRepository()
        {
            TicketsList = new List<Ticket>();
        }
    }
}
