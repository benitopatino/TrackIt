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

        public ActionResult New()
        {
            var viewModel = new ProjectFormViewModel()
            {
                Project = new Project(),
                ProjectStatus = _context.ProjectStatus.ToList()
            };

            ViewBag.Title = "New Project";
            return View("ProjectsForm", viewModel);
        }

        public ActionResult Edit(string id)
        {
            var project = _context.Projects
                .Include(p => p.ProjectStatus)
                .SingleOrDefault(p => p.Id == id);
            if (project == null)
                return HttpNotFound();

            var viewModel = new ProjectFormViewModel()
            {
                Project = project,
                ProjectStatus = _context.ProjectStatus.ToList()
            };

            ViewBag.Title = "Edit Project";
            return View("ProjectsForm", viewModel);
        }

        public ActionResult Save(Project project)
        {
            // Return back to the ProjectForm if the model is invalid
            if (!ModelState.IsValid)
            {
                var viewModel = new ProjectFormViewModel()
                {
                    Project = new Project(),
                    ProjectStatus = _context.ProjectStatus.ToList()
                };

                return View("ProjectsForm", viewModel);
            }

            // Create a new project
            if (project.Id == null)
            {
                // Set UUID
                Guid g = Guid.NewGuid();
                project.Id = g.ToString("N");
                _context.Projects.Add(project);
            }
            else
            {
                // Edit project
                var projectInDb = _context.Projects.Single(p => p.Id == project.Id);

                // update fields
                projectInDb.Name = project.Name;
                projectInDb.ProjectStatusId = project.ProjectStatusId;
            }


            _context.SaveChanges();
            return RedirectToAction("Index", "Projects");
        }


        private Dictionary<string, Dictionary<string, int>> GetTicketStats(IEnumerable<Project> projects)
        {

            IEnumerable<Status> statusList = _context.Status.ToList();

            // PROJECT ID , <STATUS NAME, COUNT>
            Dictionary<string, Dictionary<string, int>> tempDict = new Dictionary<string, Dictionary<string, int>>();

            // TEMP 
            Dictionary<string, int> statusStats = new Dictionary<string, int>();

            foreach (var p in projects)
            {
                foreach (var s in statusList)
                {
                    string test = s.Name;
                    int count = _context.Tickets.Where(t => t.StatusId == s.Id).Where(t => t.ProjectId == p.Id).ToList().Count;
                    statusStats.Add(s.Name, count);
                }

                tempDict.Add(p.Id, new Dictionary<string, int>(statusStats));
                statusStats.Clear();
            }

            return tempDict;

        }
    }
}