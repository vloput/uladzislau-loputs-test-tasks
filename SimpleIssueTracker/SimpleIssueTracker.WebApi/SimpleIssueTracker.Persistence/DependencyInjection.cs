using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SimpleIssueTracker.Application.Interfaces;

namespace SimpleIssueTracker.Persistence
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services)
        {
            services.AddDbContext<IssueTrackerDbContext>(options =>
            {
                options.UseInMemoryDatabase("IssueTrackerDb");
            });

            services.AddScoped<IIssueTrackerDbContext>(provider =>
                provider.GetService<IssueTrackerDbContext>());

            return services;
        }
    }
}
