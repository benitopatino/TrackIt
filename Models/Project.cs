using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TrackIt.Models
{
    public class Project
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public ProjectStatus ProjectStatus { get; set; }
        public byte ProjectStatusId { get; set; }

    }
}