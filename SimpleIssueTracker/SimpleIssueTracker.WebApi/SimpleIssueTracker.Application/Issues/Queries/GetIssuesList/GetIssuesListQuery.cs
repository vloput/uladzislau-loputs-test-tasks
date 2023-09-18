using MediatR;
using SimpleIssueTracker.Domain;

namespace SimpleIssueTracker.Application.Issues.Queries.GetIssuesList
{
    public class GetIssuesListQuery : IRequest<IList<Issue>>
    {
    }
}
