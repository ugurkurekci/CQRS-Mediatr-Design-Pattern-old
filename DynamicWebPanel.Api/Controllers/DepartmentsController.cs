using DynamicWebPanel.Business.Commands.Departments;
using DynamicWebPanel.Business.DTOs.Departments;
using DynamicWebPanel.Business.Queries.Departments;
using DynamicWebPanel.Business.Utilities.Constans;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DynamicWebPanel.Api.Controllers
{
    [Route("api/[controller]"), ApiController]
    public class DepartmentsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public DepartmentsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [Authorize]
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _mediator.Send(new DepartmentsGetAllQuery()));
        }

        [HttpPost("Post")]
        public async Task<IActionResult> Post([FromBody] DepartmentsCreateDto authorizationsCreateDto)
        {
            int id = await _mediator.Send(new DepartmentsCommandCreate(authorizationsCreateDto));
            return StatusCode(HttpStatusCodes.Created, id);
        }

        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _mediator.Send(new DepartmentsCommandDelete(id));
            return NoContent();

        }
    }
}
