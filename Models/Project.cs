using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace TrackIt.Models
{
    public class Project
    {
        public string Id { get; set; }
        [Required]
        [Display(Name = "Project Name")]
        public string Name { get; set; }
        public ProjectStatus ProjectStatus { get; set; }

        [Required]
        [Display(Name="Project Status")]
        public byte ProjectStatusId { get; set; }

    }
}