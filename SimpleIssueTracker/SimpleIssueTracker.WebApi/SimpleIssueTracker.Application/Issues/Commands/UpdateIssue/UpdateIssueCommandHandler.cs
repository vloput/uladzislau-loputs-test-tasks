using MediatR;
using Microsoft.EntityFrameworkCore;
using SimpleIssueTracker.Application.Common.Exceptions;
using SimpleIssueTracker.Application.Interfaces;
using SimpleIssueTracker.Domain;

namespace SimpleIssueTracker.Application.Issues.Commands.UpdateIssue
{
    public class UpdateIssueCommandHandler : IRequestHandler<UpdateIssueCommand, Issue>
    {
        private readonly IIssueTrackerDbContext _dbContext;

        public UpdateIssueCommandHandler(IIssueTrackerDbContext dbContext) =>
            _dbContext = dbContext;

        public async Task<Issue> Handle(UpdateIssueCommand request, CancellationToken cancellationToken)
        {
            var entity =
                await _dbContext.Issues.FirstOrDefaultAsync(issue => issue.Id == request.Id, cancellationToken);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Issue), request.Id);
            }

            entity.Title = request.Title;
            entity.Description = request.Description;
            entity.Status = request.Status;
            entity.UpdatedAt = DateTime.UtcNow;

            await _dbContext.SaveChangesAsync(cancellationToken);

            return entity;
        }
    }
}
