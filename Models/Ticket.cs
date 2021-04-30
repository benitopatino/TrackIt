using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TrackIt.Models
{
    public class Ticket
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public ApplicationUser Assignee { get; set; }

        [Display(Name = "Owner")]
        public string AssigneeId { get; set; }

        public Priority Priority { get; set; }

        [Display(Name = "Priority")]
        public byte PriorityId { get; set; }
        
        public Status Status { get; set; }

        [Display(Name = "Priority")]
        public byte StatusId { get; set; }
        
        public DateTime DateCreated { get; set; }
        public DateTime? DateClosed { get; set; }
        public DateTime? DateDue { get; set; }
        public TicketType TicketType { get; set; }

        [Display(Name = "Ticket Type")]
        public byte TicketTypeId { get; set; }
        
        public Resolution Resolution { get; set; }

        [Display(Name = "Resolution")]
        public byte? ResolutionId { get; set; }
        
        public Project Project { get; set; }

        [Display(Name = "Project")]
        public string ProjectId { get; set; }

    }
}