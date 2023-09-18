using SimpleIssueTracker.Domain;

namespace SimpleIssueTracker.Persistence
{
    public class DbInitializer
    {
        public static void Initialize(IssueTrackerDbContext context)
        {
            context.Database.EnsureCreated();

            context.Issues.Add(new Issue
            {
                Id = Guid.NewGuid(),
                Title = "Initial Issue #1",
                Description = "Bar",
                Status = IssueStatus.Open,
                CreatedAt = DateTime.Now,
                UpdatedAt = null
            });

            context.Issues.Add(new Issue
            {
                Id = Guid.NewGuid(),
                Title = "Initial Issue #2",
                Description = "Test",
                Status = IssueStatus.Closed,
                CreatedAt = DateTime.Now.AddDays(-2),
                UpdatedAt = DateTime.Now.AddHours(-5)
            });

            context.SaveChanges();
        }
    }
}
