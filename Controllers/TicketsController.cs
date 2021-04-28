using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TrackIt.ViewModels;
using TrackIt.Models;
namespace TrackIt.Controllers
{
    public class TicketsController : Controller
    {

        private ApplicationDbContext _context;

        public TicketsController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Tickets
        public ActionResult Index()
        {
            return View();
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

            // SET UUID ID FOR Ticket
            Guid g = Guid.NewGuid();
            viewModel.Ticket.Id = g.ToString();

            // Set View Title
            ViewBag.Title = "New Ticket";

            return View("TicketsForm", viewModel);
        }

        public ActionResult Save(Ticket ticket)
        {

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
            }

            // Create a new Ticket
            if(ticket.Id == null)
            {
                // Set Date
                ticket.DateCreated = DateTime.Now;

                // Set UUID
                Guid g = Guid.NewGuid();
                ticket.Id = g.ToString();

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
                ticketInDb.DateCreated = ticket.DateCreated;
                ticketInDb.DateClosed = ticket.DateClosed;
                ticketInDb.DateDue = ticket.DateDue;
                ticketInDb.TicketTypeId = ticket.TicketTypeId;
                ticketInDb.ResolutionId = ticket.ResolutionId;
                ticketInDb.ProjectId = ticket.ProjectId;
            }

            _context.SaveChanges();
            return RedirectToAction("Index", "Tickets");
        }
    }
}