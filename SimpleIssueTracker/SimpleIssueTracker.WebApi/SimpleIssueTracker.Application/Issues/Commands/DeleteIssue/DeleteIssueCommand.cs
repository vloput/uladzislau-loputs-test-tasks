using MediatR;

namespace SimpleIssueTracker.Application.Issues.Commands.DeleteIssue
{
    public class DeleteIssueCommand : IRequest
    {
        public Guid Id { get; set; }
    }
}
