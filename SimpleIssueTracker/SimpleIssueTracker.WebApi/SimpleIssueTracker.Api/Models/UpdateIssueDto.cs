using SimpleIssueTracker.Domain;

namespace SimpleIssueTracker.Api.Models
{
    public class UpdateIssueDto
    {
        public string Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string Status { get; set; }
    }
}
