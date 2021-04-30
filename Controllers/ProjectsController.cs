using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TrackIt.Models;
using System.Data.Entity;
using TrackIt.ViewModels;

namespace TrackIt.Controllers
{
    public class ProjectsController : Controller
    {

        private ApplicationDbContext _context;

        public ProjectsController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }


        // GET: Projects
        public ActionResult Index()
        {
            var projects
         
            var viewModel = new ProjectListViewModel()
            {
                Projects = _context.Projects.ToList(),
                TicketStatusCount = GetTicketStatusCount

        }
            return View("List", projects);
        }


        private Dictionary<string, int> GetTicketStatusCount(string projectId)
        {

            IEnumerable<Status> statusList = _context.Status.ToList();
            Dictionary<string, int> tempDict = new Dictionary<string, int>();

            foreach(var s in statusList)
            {

                int count = _context.Tickets.Where(t => t.ProjectId == projectId).ToList().Count;
                tempDict.Add(s.Name, count);
            }

            return tempDict;

        }
    }
}