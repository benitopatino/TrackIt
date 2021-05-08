using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace TrackIt.Models
{
    public class Comment
    {
        public string Id { get; set; }
        public string Content { get; set; }
        public ApplicationUser Author { get; set; }

        [Required]
        public string AuthorId { get; set; }

        public Ticket Ticket { get; set; }

        [Required]
        public string TicketId { get; set; }
        public DateTime DateCreated { get; set; }

    }
}