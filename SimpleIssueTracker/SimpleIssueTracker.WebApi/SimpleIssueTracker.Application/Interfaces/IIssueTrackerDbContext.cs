using Microsoft.EntityFrameworkCore;
using SimpleIssueTracker.Domain;

namespace SimpleIssueTracker.Application.Interfaces
{
    public interface IIssueTrackerDbContext
    {
        DbSet<Issue> Issues { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
