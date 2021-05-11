using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TrackIt.Models;

namespace TrackIt.ViewModels
{
    public class ProjectFormViewModel
    {
        public Project Project { get; set; }
        public IEnumerable<ProjectStatus> ProjectStatus { get; set; }

    }
}