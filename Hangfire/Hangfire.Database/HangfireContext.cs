using Hangfire.Model;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Hangfire.Database
{
    public class HangfireContext : DbContext
    {
        public HangfireContext() { }

        public HangfireContext(DbContextOptions<HangfireContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Driver> Bookings { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=.;Database=HangfireDb;User Id=azra;Password=Password123!;Trusted_Connection=SSPI;Encrypt=false;TrustServerCertificate=true;");
            }
        }
    }
}