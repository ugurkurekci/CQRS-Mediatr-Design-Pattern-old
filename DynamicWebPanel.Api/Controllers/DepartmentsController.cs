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

        [HttpGet]
        [ProducesResponseType(200)]

        public async Task<IActionResult> GetAll()
        {
            return Ok(await _mediator.Send(new DepartmentsGetAllQuery()));
        }

        [ProducesResponseType(201)]
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] DepartmentsCreateDto departmentsCreateDto)
        {
            int id = await _mediator.Send(new DepartmentsCommandCreate(departmentsCreateDto));
            return StatusCode(HttpStatusCodes.Created, id);
        }

        [ProducesResponseType(204)]
        [HttpPut("{id}")]
        public async Task<IActionResult> Put([FromBody] DepartmentsUpdateDto departmentsUpdateDto, int id)
        {
            int ID = await _mediator.Send(new DepartmentsCommandUpdate(departmentsUpdateDto, id));
            return NoContent();

        }

        [ProducesResponseType(204)]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _mediator.Send(new DepartmentsCommandDelete(id));
            return NoContent();

        }
    }
}
