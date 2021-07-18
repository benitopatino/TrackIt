using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TrackIt.Models
{
    public class ProjectMember
    {
        public string Id { get; set; }
        public ApplicationUser Member { get; set; }

        [Display(Name = "Users")]
        public string MemberId { get; set; }
        public Project Project { get; set; }
        public string ProjectId { get; set; }

        public ProjectMember()
        {

        }

        public ProjectMember(string projectId)
        {
            this.ProjectId = projectId;
        }

    }
}