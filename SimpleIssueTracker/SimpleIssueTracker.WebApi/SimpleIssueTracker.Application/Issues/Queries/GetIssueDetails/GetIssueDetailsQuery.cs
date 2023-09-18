using MediatR;
using SimpleIssueTracker.Domain;

namespace SimpleIssueTracker.Application.Issues.Queries.GetIssueDetails
{
    public class GetIssueDetailsQuery : IRequest<Issue>
    {
        public Guid Id { get; set; }
    }
}
