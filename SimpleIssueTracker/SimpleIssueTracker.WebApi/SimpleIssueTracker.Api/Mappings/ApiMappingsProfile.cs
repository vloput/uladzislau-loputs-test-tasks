using AutoMapper;
using SimpleIssueTracker.Api.Models;
using SimpleIssueTracker.Application.Issues.Commands.CreateIssue;
using SimpleIssueTracker.Application.Issues.Commands.UpdateIssue;
using SimpleIssueTracker.Domain;

namespace SimpleIssueTracker.Api.Mappings
{
    public class ApiMappingsProfile : Profile
    {
        public ApiMappingsProfile()
        {
            CreateMap<CreateIssueDto, CreateIssueCommand>();
            CreateMap<UpdateIssueDto, UpdateIssueCommand>();
            CreateMap<Issue, IssueDto>();
        }
    }
}
