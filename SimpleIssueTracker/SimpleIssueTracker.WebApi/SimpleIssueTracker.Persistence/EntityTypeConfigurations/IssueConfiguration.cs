using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SimpleIssueTracker.Domain;

namespace SimpleIssueTracker.Persistence.EntityTypeConfigurations
{
    public class IssueConfiguration : IEntityTypeConfiguration<Issue>
    {
        public void Configure(EntityTypeBuilder<Issue> builder)
        {
            builder.HasKey(issue => issue.Id);
            builder.HasIndex(issue => issue.Id).IsUnique();
        }
    }
}
