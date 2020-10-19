using System.Threading;
using System.Threading.Tasks;
using DotNetCoreAuthentication.Data;
using DotNetCoreAuthentication.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DotNetCoreAuthentication.Repository
{
    public class DotNetCoreAuthenticationContext : IdentityDbContext<ApplicationUser> 
    {
        public DotNetCoreAuthenticationContext(DbContextOptions<DotNetCoreAuthenticationContext> options)
            : base(options)
        {
        }
        public DbSet<MailBox> MailBoxes { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
           
        }
     

    }
}
