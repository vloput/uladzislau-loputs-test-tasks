using MediatR;
using SimpleIssueTracker.Domain;

namespace SimpleIssueTracker.Application.Issues.Commands.UpdateIssue
{
    public class UpdateIssueCommand : IRequest<Issue>
    {
        public Guid Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public IssueStatus Status { get; set; }
    }
}
