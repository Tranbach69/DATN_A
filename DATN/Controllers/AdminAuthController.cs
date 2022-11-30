using DATN.Application.AuthHandler.Commands.TokenCommandAdmin;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace DATN.Api.Controllers
{
	[Route("api/auth/admin")]
	[ApiController]
    public class AdminAuthController : ControllerBase
    {
        private readonly IMediator _mediator;
        public AdminAuthController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost]
        public Task<TokenCommandAdminResponse> Token([FromBody] TokenCommandAdmin command) => _mediator.Send(command);
    }
}
