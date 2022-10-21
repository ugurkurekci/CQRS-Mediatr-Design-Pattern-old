using DynamicWebPanel.Business.Commands.Users;
using DynamicWebPanel.Business.DTOs.Users;
using DynamicWebPanel.Business.Queries.Users;
using DynamicWebPanel.Business.Utilities.Constans;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DynamicWebPanel.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UsersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _mediator.Send(new UsersGetAllQuery()));
        }

        [HttpGet("{departmentsid}")]
        public async Task<IActionResult> GetByDepartments(int departmentsID)
        {
            return Ok(await _mediator.Send(new UsersGetByDepartmentsQuery(departmentsID)));
        }

        [HttpPost]
        [ProducesResponseType(201)]
        public async Task<IActionResult> Post([FromBody] UsersCreateDto usersCreateDto)
        {
            int id = await _mediator.Send(new UsersCommandCreate(usersCreateDto));
            return StatusCode(HttpStatusCodes.Created, id);
        }

        [ProducesResponseType(204)]
        [HttpPut("{id}")]
        public async Task<IActionResult> Put([FromBody] UsersUpdateDto usersUpdateDto, int ID)
        {
            int id = await _mediator.Send(new UsersCommandUpdate(ID, usersUpdateDto));
            return NoContent();

        }

        [ProducesResponseType(204)]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _mediator.Send(new UsersCommandDelete(id));
            return NoContent();

        }
    }
}
