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

            ViewBag.Title = "New Ticket";

            return View("TicketsForm", viewModel);
        }
    }
}