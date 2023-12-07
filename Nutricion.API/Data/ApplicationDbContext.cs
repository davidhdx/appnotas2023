using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Nutricion.API.Models;

namespace Nutricion.API.Data
{
    public class ApplicationDbContext:IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions options):base(options)
        {

        }

        protected override void OnModelCreating( ModelBuilder builder) 
        {
            base.OnModelCreating(builder);
        }

        public DbSet<Note> Note { get; set; }

        public DbSet<UserInfo> Accounts { get; set; }
    }
}
