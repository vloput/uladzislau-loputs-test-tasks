using Microsoft.EntityFrameworkCore;
using SimpleIssueTracker.Application.Interfaces;
using SimpleIssueTracker.Domain;
using SimpleIssueTracker.Persistence.EntityTypeConfigurations;

namespace SimpleIssueTracker.Persistence
{
    public class IssueTrackerDbContext : DbContext, IIssueTrackerDbContext
    {
        public DbSet<Issue> Issues { get; set; }

        public IssueTrackerDbContext(DbContextOptions<IssueTrackerDbContext> options)
            : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new IssueConfiguration());
            base.OnModelCreating(builder);
        }
    }
}
