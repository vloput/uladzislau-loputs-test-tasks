using SimpleIssueTracker.Domain;

namespace SimpleIssueTracker.Api.Models
{
    public class IssueDto
    {
        public Guid Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string Status { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }
    }
}
