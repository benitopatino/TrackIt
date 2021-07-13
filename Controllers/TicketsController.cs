  using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TrackIt.ViewModels;
using TrackIt.Models;
using System.Data.Entity;
using Microsoft.AspNet.Identity;


namespace TrackIt.Controllers
{
    public class TicketsController : Controller
    {

        private ApplicationDbContext _context;

        public TicketsController()
        {
            _context = new ApplicationDbContext();
            _context.ConfigureUsername(() => User.Identity.Name);
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Tickets
        // Cutom Route
        public ActionResult GetTicketsByProject(string projectId)
        {
            var tickets = _context.Tickets
                .Include(t => t.Priority)
                .Include(t => t.Status)
                .Include(t => t.TicketType)
                .Include(t => t.Assignee)
                .Where(t => t.ProjectId == projectId).ToList();
            var viewModel = new TicketsListViewModel() {
                Tickets = tickets,
                ProjectName = _context.Projects.Single(p => p.Id == projectId).Name,
                TicketStatusCount = GetTicketsStatusCount(tickets)
            };

            return View("List",viewModel);
        }

        public ActionResult Details(string id)
        {
            // Get current ticket
            var ticket = _context.Tickets
                .Include(t => t.Priority)
                .Include(t => t.Status)
                .Include(t => t.TicketType)
                .Include(t => t.Assignee)
                .Include(t => t.Project)
                .Include(t => t.Resolution)
                .SingleOrDefault(t => t.Id == id);

            // Get Current User ID
            string currentUserId = User.Identity.GetUserId<String>();
            
            // Get Current ticket id
            string ticketId = id;

            // Get all comments associated with this ticket
            var ticketComments = _context.Comments
                .Include(c => c.Author)
                .Where(c => c.TicketId == ticketId).ToList();

            

            var viewModel = new TicketDetailsViewModel()
            {
                Ticket = ticket,
                Comment = new Comment(ticketId, currentUserId),
                TicketComments = ticketComments
            };


            return View("TicketDetails", viewModel);
        }

        // POST: Ticket
        public ActionResult New()
        {
            var viewModel = new TicketFormViewModel()
            {
                Ticket = new Ticket(),
                TicketTypes = _context.TicketTypes.ToList(),
                Resolutions = _context.Resolutions.ToList(),
                Status = _context.Status.ToList(),
                Priorities = _context.Priorities.ToList(),
                Owners = _context.Users.ToList(),
                Projects = _context.Projects.ToList()
            };



            // Set View Title
            ViewBag.Title = "New Ticket";

            return View("TicketsForm", viewModel);
        }


        // EDIT
        public ActionResult Edit(string id)
        {
            var ticket = _context.Tickets
                .Include(t => t.Priority)
                .Include(t => t.Status)
                .Include(t => t.Resolution)
                .Include(t => t.TicketType)
                .Include(t => t.Assignee)
                .SingleOrDefault(t => t.Id == id);

            if (ticket == null)
                return HttpNotFound();

            var viewModel = new TicketFormViewModel()
            {
                Ticket = ticket,
                TicketTypes = _context.TicketTypes.ToList(),
                Resolutions = _context.Resolutions.ToList(),
                Status = _context.Status.ToList(),
                Priorities = _context.Priorities.ToList(),
                Owners = _context.Users.ToList(),
                Projects = _context.Projects.ToList()
            };

            ViewBag.Title = "Edit Ticket";
            return View("TicketsForm", viewModel);


        }


        public ActionResult Save(Ticket ticket)
        {
            // Return back to the TicketsForm if the model is invalid
            if (!ModelState.IsValid)
            {
                var viewModel = new TicketFormViewModel()
                {
                    Ticket = new Ticket(),
                    TicketTypes = _context.TicketTypes.ToList(),
                    Resolutions = _context.Resolutions.ToList(),
                    Status = _context.Status.ToList(),
                    Priorities = _context.Priorities.ToList(),
                    Owners = _context.Users.ToList(),
                    Projects = _context.Projects.ToList()
                };

                return View("TicketsForm", viewModel);
            }

            // Create a new Ticket
            if(ticket.Id == null)
            {
                // Set Date
                ticket.DateCreated = DateTime.Now;

                // Set UUID
                Guid g = Guid.NewGuid();
                ticket.Id = g.ToString("N");

                // save ticket
                _context.Tickets.Add(ticket);

            }
            else 
            {
                // Edit ticket
                var ticketInDb = _context.Tickets.Single(t => t.Id == ticket.Id);

                // update fields
                ticketInDb.Title = ticket.Title;
                ticketInDb.Description = ticket.Description;
                ticketInDb.AssigneeId = ticket.AssigneeId;
                ticketInDb.PriorityId = ticket.PriorityId;
                ticketInDb.StatusId = ticket.StatusId;
                ticketInDb.DateDue = ticket.DateDue;
                ticketInDb.TicketTypeId = ticket.TicketTypeId;
                ticketInDb.ResolutionId = ticket.ResolutionId;
                ticketInDb.ProjectId = ticket.ProjectId;
            }

            _context.SaveChanges();
            return RedirectToAction("Details", "Tickets", new { id = ticket.Id});
        }
        
        public ActionResult History(string id)
        {
            // Get all the logs for a specific Ticket
            var auditLogs = _context.GetLogs<Ticket>(id).ToList();
            var orderByDateLogs = auditLogs.OrderByDescending(t => t.EventDateUTC);

            return View("TicketHistory", orderByDateLogs);
        }


        private Dictionary<string, int> GetTicketsStatusCount(IEnumerable<Ticket> tickets)
        {

            IEnumerable<Status> statusList = _context.Status.ToList();
            Dictionary<string, int> tempDict = new Dictionary<string, int>();
            foreach(var s in statusList)
            {
                string testName = s.Name;
                int count = tickets.Where(t => t.StatusId == s.Id).ToList().Count;
                tempDict.Add(testName, count);
            }

            return tempDict;
        }

    }
}