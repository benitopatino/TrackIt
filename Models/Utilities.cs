using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TrackIt.Models
{
    public static class Utilities
    {
        public static class ProjectStatus
        {
            // Project Status
            public static string Completed = "Completed";
            public static string OnHold = "On Hold";
            public static string OnTrack = "On Track";
            public static string New = "New";
        }

        public static class UserRoles
        {
            public static string ProjectManager = "ProjectManager";
        }



    }
}