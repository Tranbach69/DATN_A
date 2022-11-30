using DATN.Application.AccountAdminHandler.Commands.CreateAccountAdmin;
using DATN.Application.AccountAdminHandler.Commands.DeleteAccountAdmin;
using DATN.Application.AccountAdminHandler.Commands.UpdateAccountAdmin;
using DATN.Application.AccountAdminHandler.Queries.GetAccountAdmin;
using DATN.Application.AccountAdminHandler.Queries.GetAccountAdminPaging;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace DATN.Api.Controllers
{
	[Route("api/account/admin")]
	[ApiController]
	public class AccountAdminController : ControllerBase
	{
		private readonly IMediator _mediator;

		public AccountAdminController(IMediator mediator)
		{
			_mediator = mediator;
		}
		[HttpPost]
		[ProducesResponseType(StatusCodes.Status200OK)]
		public async Task<ActionResult<bool>> Create([FromBody] CreateAccountAdminCommand command)
		{
			var result = await _mediator.Send(command);
			return Ok(result);
		}

		[HttpPut("changepass")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		public async Task<ActionResult<bool>> ChangePassword([FromBody] UpdateAccountAdminCommand command)
		{
			var result = await _mediator.Send(command);
			return result.Succeeded ? Ok(result) : BadRequest(result);
		}

		[HttpGet("{id:int}")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		public async Task<ActionResult<bool>> Get(int id)
		{
			var query = new GetAccountAdminQuery(id);
			var result = await _mediator.Send(query);
			return Ok(result);
		}


		[HttpGet]
		[ProducesResponseType(StatusCodes.Status200OK)]
		public async Task<ActionResult<bool>> Get([FromQuery] GetAccountAdminPagingQuery queries)
		{
			var result = await _mediator.Send(queries);
			return Ok(result);
		}

		[HttpDelete("{id:int}")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		public async Task<ActionResult<bool>> Delete(int id)
		{
			var query = new DeleteAccountAdminCommand(id);
			var result = await _mediator.Send(query);
			return Ok(result);
		}
	}
}
