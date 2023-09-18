using MediatR;
using Microsoft.EntityFrameworkCore;
using SimpleIssueTracker.Application.Common.Exceptions;
using SimpleIssueTracker.Application.Interfaces;
using SimpleIssueTracker.Domain;

namespace SimpleIssueTracker.Application.Issues.Queries.GetIssueDetails
{
    public class GetIssueDetailsQueryHandler : IRequestHandler<GetIssueDetailsQuery, Issue>
    {
        private readonly IIssueTrackerDbContext _dbContext;

        public GetIssueDetailsQueryHandler(IIssueTrackerDbContext dbContext) =>
            _dbContext = dbContext;

        public async Task<Issue> Handle(GetIssueDetailsQuery request, CancellationToken cancellationToken)
        {
            var entity =
                await _dbContext.Issues.FirstOrDefaultAsync(issue => issue.Id == request.Id, cancellationToken);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Issue), request.Id);
            }

            return entity;
        }
    }
}
