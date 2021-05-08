using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace TrackIt.Models
{
    public class Comment
    {

        public Comment()
        {

        }

        public Comment(string ticketId, string userId)
        {
            TicketId = ticketId;
            AuthorId = userId;
        }

        public string Id { get; set; }

        [Required]
        public string Content { get; set; }
        public ApplicationUser Author { get; set; }
        public string  AuthorId { get; set; }
        public Ticket Ticket { get; set; }
        public string TicketId { get; set; }
        public DateTime DateCreated { get; set; }

    }
}