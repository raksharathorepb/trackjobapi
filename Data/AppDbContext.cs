using JobTrackerAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace TrackJobAPI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<JobApplication> JobApplications { get; set; }
    }
}
