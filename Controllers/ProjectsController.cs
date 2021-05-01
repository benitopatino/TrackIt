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

            var projects = _context.Projects.Include(s => s.ProjectStatus).ToList();

            var viewModel = new ProjectListViewModel()
            {
                Projects = projects,
                TicketStats = GetTicketStats(projects)

            };

            return View("List", viewModel);
        }


        private Dictionary<string, Dictionary<string, int>> GetTicketStats(IEnumerable<Project> projects)
        {

            IEnumerable<Status> statusList = _context.Status.ToList();
            Dictionary<string, Dictionary<string, int>> tempDict = new Dictionary<string, Dictionary<string, int>>();
            Dictionary<string, int> statusStats = new Dictionary<string, int>();

            foreach (var p in projects)
            {
                foreach (var s in statusList)
                {
                    string test = s.Name;
                    int count = _context.Tickets.Where(t => t.StatusId == s.Id).Where(t => t.ProjectId == p.Id).ToList().Count;
                    statusStats.Add(s.Name, count);
                }

                tempDict.Add(p.Id, statusStats);
                statusStats.Clear();
            }

            return tempDict;

        }
    }
}