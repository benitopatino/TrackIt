using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TrackIt.Models;

namespace TrackIt.ViewModels
{
    public class ProjectListViewModel
    {
        public IEnumerable<Project> Projects{ get; set; }
        public Dictionary<string, int> TicketStatusCount { get; set; }

    }
}