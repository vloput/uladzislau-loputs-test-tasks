using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SimpleIssueTracker.Api.Models;
using SimpleIssueTracker.Application.Issues.Commands.CreateIssue;
using SimpleIssueTracker.Application.Issues.Commands.DeleteIssue;
using SimpleIssueTracker.Application.Issues.Commands.UpdateIssue;
using SimpleIssueTracker.Application.Issues.Queries.GetIssuesList;

namespace SimpleIssueTracker.Api.Controllers
{
    [Route("api/[controller]")]
    public class IssuesController : BaseController
    {
        private IMapper _mapper;

        public IssuesController(IMapper mapper) =>
            _mapper = mapper;

        [HttpGet]
        public async Task<ActionResult<IList<IssueDto>>> GetAll()
        {
            var query = new GetIssuesListQuery();
            var issues = await Mediator.Send(query);

            var issuesDto = _mapper.Map<IList<IssueDto>>(issues);

            return Ok(issuesDto);
        }

        [HttpPost]
        [Authorize]
        public async Task<ActionResult<IssueDto>> Create([FromBody]CreateIssueDto createIssueDto)
        {
            var command = _mapper.Map<CreateIssueCommand>(createIssueDto);
            var entity = await Mediator.Send(command);

            var issueDto = _mapper.Map<IssueDto>(entity);

            return Ok(issueDto);
        }

        [HttpPut]
        [Authorize]
        public async Task<ActionResult<IssueDto>> Update([FromBody]UpdateIssueDto updateIssueDto)
        {
            var command = _mapper.Map<UpdateIssueCommand>(updateIssueDto);
            var entity = await Mediator.Send(command);

            var issueDto = _mapper.Map<IssueDto>(entity);

            return Ok(issueDto);
        }

        [HttpDelete]
        [Authorize]
        public async Task<IActionResult> Delete(Guid guid)
        {
            var command = new DeleteIssueCommand
            {
                Id = guid
            };
            await Mediator.Send(command);

            return NoContent();
        }
    }
}
