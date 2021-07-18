using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TrackIt.Models;

namespace TrackIt.ViewModels
{
    public class ProjectMembersFormViewModel
    {
        public Project Project { get; set; }
        public IEnumerable<ApplicationUser> Users { get; set; }
        public ProjectMember ProjectMember { get; set; }
        public List<ProjectMember> ProjectMembers { get; set; }
    }
}