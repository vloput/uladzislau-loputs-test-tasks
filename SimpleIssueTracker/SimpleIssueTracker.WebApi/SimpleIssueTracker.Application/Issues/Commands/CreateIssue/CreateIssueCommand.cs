using MediatR;
using SimpleIssueTracker.Domain;

namespace SimpleIssueTracker.Application.Issues.Commands.CreateIssue
{
    public class CreateIssueCommand : IRequest<Issue>
    {
        public string Title { get; set; }

        public string Description { get; set; }
    }
}
