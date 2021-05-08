using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TrackIt.Models;
namespace TrackIt.ViewModels
{
    public class TicketDetailsViewModel
    {

        public Ticket Ticket { get; set; }
        public Comment Comment{ get; set; }
        public IEnumerable<Comment> TicketComments { get; set; }

    }
}