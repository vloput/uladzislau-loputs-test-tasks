using MediatR;
using Microsoft.EntityFrameworkCore;
using SimpleIssueTracker.Application.Common.Exceptions;
using SimpleIssueTracker.Application.Interfaces;
using SimpleIssueTracker.Domain;

namespace SimpleIssueTracker.Application.Issues.Commands.DeleteIssue
{
    public class DeleteIssueCommandHandler : IRequestHandler<DeleteIssueCommand>
    {
        private readonly IIssueTrackerDbContext _dbContext;

        public DeleteIssueCommandHandler(IIssueTrackerDbContext dbContext) =>
            _dbContext = dbContext;

        public async Task Handle(DeleteIssueCommand request, CancellationToken cancellationToken)
        {
            var entity =
                await _dbContext.Issues.FirstOrDefaultAsync(issue => issue.Id == request.Id, cancellationToken);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Issue), request.Id);
            }

            _dbContext.Issues.Remove(entity);
            await _dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
