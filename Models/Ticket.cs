using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TrackIt.Models
{
    [TrackChanges]
    public class Ticket
    {
        public string Id { get; set; }

        [Required(ErrorMessage = "Please enter the ticket's title")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Please enter a description about the ticket")]
        public string Description { get; set; }
        public ApplicationUser Assignee { get; set; }

        [Display(Name = "Owner")]
        public string AssigneeId { get; set; }

        public Priority Priority { get; set; }

        [Display(Name = "Priority")]
        [Required]
        public byte PriorityId { get; set; }
        
        public Status Status { get; set; }

        [Display(Name = "Status")]
        [Required]
        public byte StatusId { get; set; }
        
        public DateTime DateCreated { get; set; }

        [Display(Name = "Date Due")]
        public DateTime? DateDue { get; set; }
        public TicketType TicketType { get; set; }

        [Display(Name = "Ticket Type")]
        [Required]
        public byte TicketTypeId { get; set; }
        
        public Resolution Resolution { get; set; }

        [Display(Name = "Resolution")]
        public byte? ResolutionId { get; set; }
        
        public Project Project { get; set; }

        [Display(Name = "Project")]
        [Required]
        public string ProjectId { get; set; }

    }
}