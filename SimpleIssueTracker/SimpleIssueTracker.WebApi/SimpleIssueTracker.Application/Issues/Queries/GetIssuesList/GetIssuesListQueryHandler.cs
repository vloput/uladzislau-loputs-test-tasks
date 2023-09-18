using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SimpleIssueTracker.Application.Interfaces;
using SimpleIssueTracker.Domain;

namespace SimpleIssueTracker.Application.Issues.Queries.GetIssuesList
{
    public class GetIssuesListQueryHandler : IRequestHandler<GetIssuesListQuery, IList<Issue>>
    {
        private readonly IIssueTrackerDbContext _dbContext;

        public GetIssuesListQueryHandler(IIssueTrackerDbContext dbContext) =>
            _dbContext = dbContext;

        public async Task<IList<Issue>> Handle(
            GetIssuesListQuery request, CancellationToken cancellationToken)
        {
            var issues = await _dbContext.Issues.ToListAsync(cancellationToken);

            return issues;
        }
    }
}
