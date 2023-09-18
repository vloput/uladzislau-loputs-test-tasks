namespace SimpleIssueTracker.Domain
{
    public enum IssueStatus
    {
        Open,
        Closed
    }

    public class Issue
    {
        public Guid Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public IssueStatus Status { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }
    }
}
