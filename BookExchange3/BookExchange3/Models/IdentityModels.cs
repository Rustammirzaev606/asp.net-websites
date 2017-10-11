using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace BookExchange3.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class BooksDbContext : IdentityDbContext<ApplicationUser>
    {
        public BooksDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static BooksDbContext Create()
        {
            return new BooksDbContext();
        }

        public System.Data.Entity.DbSet<BookExchange3.Models.Books> Books { get; set; }

        public System.Data.Entity.DbSet<BookExchange3.Models.Reserve> Reserves { get; set; }

        public System.Data.Entity.DbSet<BookExchange3.Models.Request> Requests { get; set; }
    }
}