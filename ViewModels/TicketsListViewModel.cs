using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TrackIt.Models;

namespace TrackIt.ViewModels
{
    public class TicketsListViewModel
    {
        public IEnumerable<Ticket> Tickets { get; set; }
        public string ProjectName { get; set; }
        public Dictionary<string, int> TicketStatusCount;



    }
}