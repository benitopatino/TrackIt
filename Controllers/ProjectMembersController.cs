using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TrackIt.ViewModels;
using System.Data.Entity;
using TrackIt.Models;

namespace TrackIt.Controllers
{
    public class ProjectMembersController : Controller
    {
        private ApplicationDbContext _context;

        public ProjectMembersController()
        {
            _context = new ApplicationDbContext();
            
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: ProjectMembers
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AddProjectMembers(string projectId)
        {
            // Load project
            var project = _context.Projects
                .Include(p => p.ProjectStatus)
                .SingleOrDefault(p => p.Id.Equals(projectId));

            // load project member
            var projectMembers = _context.ProjectMembers
                .Include(m => m.Member)
                .Include(m => m.Project)
                .Where(m => m.ProjectId.Equals(projectId)).ToList();

            // All Users
            var users = _context.Users.ToList().Where(u => u.Roles.Count < 1);

            var usersNotAssigned = users.Where(u => projectMembers.All(p2 => p2.MemberId != u.Id));

            var viewModel = new ProjectMembersFormViewModel()
            {
                Project = project,
                Users = usersNotAssigned,
                ProjectMembers = projectMembers,
                ProjectMember = new ProjectMember(projectId)
            };

            return View("ProjectMembersForm",viewModel);
        }

        public ActionResult Save(ProjectMember projectMember)
        {
            if (string.IsNullOrEmpty(projectMember.Id))
            {
                // set UUID
                Guid g = Guid.NewGuid();
                projectMember.Id = g.ToString("N");

                // Save to DB
                _context.ProjectMembers.Add(projectMember);
            }


            _context.SaveChanges();
            return RedirectToAction("AddProjectMembers", "ProjectMembers", new { projectId = projectMember.ProjectId });
        }

        public ActionResult Delete(string projectMemberId, string projectId)
        {
            var deleteMember = _context.ProjectMembers.FirstOrDefault(m => m.Id.Equals(projectMemberId));

            _context.ProjectMembers.Remove(deleteMember);
            _context.SaveChanges();

            return RedirectToAction("AddProjectMembers", "ProjectMembers", new { projectId = projectId });

        }
    }
}