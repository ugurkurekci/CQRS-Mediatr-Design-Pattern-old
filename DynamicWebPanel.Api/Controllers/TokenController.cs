using DynamicWebPanel.Business.Commands.Tokens;
using DynamicWebPanel.Business.CrossCuttingConcerns.Jwt.Models;
using DynamicWebPanel.Business.DTOs.Login;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DynamicWebPanel.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TokenController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("Access")]
        public async Task<IActionResult> Access([FromBody] LoginDto loginDto, CancellationToken cancellationToken = new())
        {
            string Device = Request.Headers["User-Agent"].ToString();
            string remoteIpAddress = Request.HttpContext.Connection.RemoteIpAddress?.ToString();

            AccessTokenRequest accessToken = new AccessTokenRequest
            {
                Device = Device,
                IpAdress = remoteIpAddress,
                Email = loginDto.Email,
                Password = loginDto.Password
            };
            return Ok(await _mediator.Send(new AccessTokenCommand(accessToken), cancellationToken));
        }

        [HttpPost("Refresh")]
        public async Task<IActionResult> Refresh([FromBody] RefreshTokenRequest refreshRequest, CancellationToken cancellationToken = new())
        {
            return Ok(await _mediator.Send(new RefreshTokenCommand(refreshRequest), cancellationToken));
        }

    }
}
