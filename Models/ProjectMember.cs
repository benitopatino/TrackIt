using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TrackIt.Models
{
    public class ProjectMember
    {
        public string Id { get; set; }
        public ApplicationUser Member { get; set; }
        public string MemberId { get; set; }
        public Project Project { get; set; }
        public string ProjectId { get; set; }

    }
}