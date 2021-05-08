using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TrackIt.Models;
using TrackIt.ViewModels;

namespace TrackIt.Controllers
{
    public class CommentsController : Controller
    {
        private ApplicationDbContext _context;

        public CommentsController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Comments
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Save(Comment comment)
        {

            // Return back to the TicketsForm if the model is invalid
            if (!ModelState.IsValid)
            {

                return RedirectToAction("Details", "Tickets", new { id = comment.TicketId });
            }


            comment.DateCreated = DateTime.Now;

            // Set ID 
            Guid g = Guid.NewGuid();
            comment.Id = g.ToString("N");

            // Save comment
            _context.Comments.Add(comment);
            _context.SaveChanges();

            return RedirectToAction("Details", "Tickets", new { id = comment.TicketId });

        }
    }
}