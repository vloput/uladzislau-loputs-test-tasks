using MediatR;
using SimpleIssueTracker.Application.Interfaces;
using SimpleIssueTracker.Domain;

namespace SimpleIssueTracker.Application.Issues.Commands.CreateIssue
{
    public class CreateIssueCommandHandler : IRequestHandler<CreateIssueCommand, Issue>
    {
        private readonly IIssueTrackerDbContext _dbContext;

        public CreateIssueCommandHandler(IIssueTrackerDbContext dbContext) =>
            _dbContext = dbContext;

        public async Task<Issue> Handle(CreateIssueCommand request, CancellationToken cancellationToken)
        {
            var issue = new Issue
            {
                Id = Guid.NewGuid(),
                Title = request.Title,
                Description = request.Description,
                Status = IssueStatus.Open,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = null
            };

            await _dbContext.Issues.AddAsync(issue, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return issue;
        }
    }
}
