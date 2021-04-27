using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TrackIt.Models; 

namespace TrackIt.ViewModels
{
    public class TicketFormViewModel
    {
        public Ticket Ticket { get; set; }
        public IEnumerable<TicketType> TicketTypes { get; set; }
        public IEnumerable<Resolution> Resolutions { get; set; }
        public IEnumerable<Status> Status { get; set; }
        public IEnumerable<Priority> Priorities { get; set; }
        public IEnumerable<ApplicationUser> Owners { get; set; }
        public IEnumerable<Project> Projects { get; set; }

    }
}