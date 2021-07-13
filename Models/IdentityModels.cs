using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.ComponentModel.DataAnnotations;
using Audit.EntityFramework;
using TrackerEnabledDbContext.Identity;
using System.Security.Principal;
using System;

namespace TrackIt.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser 
    {


        [Required(ErrorMessage ="Please Enter First Name")]
        [StringLength(255)]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Please Enter Last Name")]
        [StringLength(255)]
        public string LastName { get; set; }

        public string FullName
        {
            get
            {
                return string.Format("{0} {1}", FirstName, LastName);
            }
        }

        public string FullNameEmail
        {
            get
            {
                return string.Format("{0} {1} <{2}>", FirstName, LastName, Email);
            }
        }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);

            // Add custom user claims here
            userIdentity.AddClaim(new Claim("FullName", this.FullName));
            return userIdentity;
        }

    }



    public class ApplicationDbContext : TrackerIdentityContext<ApplicationUser> 
    {
        
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<ProjectMember> ProjectMembers{ get; set; }
        public DbSet<TicketType> TicketTypes { get; set; }
        public DbSet<Resolution> Resolutions { get; set; }
        public DbSet<Status> Status { get; set; }
        public DbSet<Priority> Priorities { get; set; }
        public DbSet<Project> Projects{ get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<ProjectStatus> ProjectStatus { get; set; }



        public ApplicationDbContext()
            : base("DefaultConnection")
        {
            
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}