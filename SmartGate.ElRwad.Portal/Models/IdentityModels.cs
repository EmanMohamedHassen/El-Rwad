using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Security.Principal;

namespace SmartGate.ElRwad.Portal.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public int EmpId { get; set; }
        public int? DepId { get; set; }
        public int SecId { get; set; }
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        //public ApplicationDbContext()
        //    : base("AuthConnection", throwIfV1Schema: false)
        //{
        //}

        public ApplicationDbContext()
            : base("AuthConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }


    public static class IdentityExtensions
    {
        public static string GetEmPId(this IIdentity identity)
        {
            var userId = identity.GetUserId();
            using (var context = new ApplicationDbContext())
            {
                var user = context.Users.FirstOrDefaultAsync(m => m.Id == userId);
                return user.Result.EmpId.ToString();
            }


        }

        public static string GetDep(this IIdentity identity)
        {
            var userId = identity.GetUserId();
            using (var context = new ApplicationDbContext())
            {
                var user = context.Users.FirstOrDefaultAsync(m => m.Id == userId);
                return user.Result.DepId.ToString();
            }


        }
    }
}