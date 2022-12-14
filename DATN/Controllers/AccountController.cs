using DATN.Application.AccountHandler.Commands.CreateAccount;
using DATN.Application.AccountHandler.Commands.DeleteAccount;
using DATN.Application.AccountHandler.Commands.UpdateAccount;
using DATN.Application.AccountHandler.Queries.GetAccount;
using DATN.Application.AccountHandler.Queries.GetAccountByImei;
using DATN.Application.AccountHandler.Queries.GetAccountByMultipleImei;
using DATN.Application.AccountHandler.Queries.GetAccountMultipleRole;
using DATN.Application.AccountHandler.Queries.GetAccountPaging;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace DATN.Api.Controllers
{
	[Route("api/account")]
	[ApiController]
	public class AccountController : ControllerBase
	{
		private readonly IMediator _mediator;

		public AccountController(IMediator mediator)
		{
			_mediator = mediator;
		}
		[HttpPost]
		[ProducesResponseType(StatusCodes.Status200OK)]
		public async Task<ActionResult<bool>> Create([FromBody] CreateAccountCommand command)
		{
			var result = await _mediator.Send(command);
			return result.Succeeded ? Ok(result) : BadRequest(result);
		}
		[HttpPut]
		[ProducesResponseType(StatusCodes.Status200OK)]
		public async Task<ActionResult<bool>> Update([FromBody] UpdateAccountCommand command)
		{
			var result = await _mediator.Send(command);
			return result.Succeeded ? Ok(result) : BadRequest(result);
		}

		[HttpPut("changepass")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		public async Task<ActionResult<bool>> ChangePassword([FromBody] UpdateAccountPassCommand command)
		{
			var result = await _mediator.Send(command);
			return result.Succeeded ? Ok(result) : BadRequest(result);
		}

		[HttpGet("{id:int}")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		public async Task<ActionResult<bool>> Get(int id)
		{
			var query = new GetAccountQuery(id);
			var result = await _mediator.Send(query);
			return Ok(result);
		}


		[HttpGet]
		[ProducesResponseType(StatusCodes.Status200OK)]
		public async Task<ActionResult<bool>> Get([FromQuery] GetAccountPagingQuery queries)
		{
			var result = await _mediator.Send(queries);
			return Ok(result);
		}

		[HttpDelete("{id:int}")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		public async Task<ActionResult<bool>> Delete(int id)
		{
			var query = new DeleteAccountCommand(id);
			var result = await _mediator.Send(query);
			return Ok(result);
		}
		[HttpGet("/api/account/imei{imei}")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		public async Task<ActionResult<bool>> Get(string imei)
		{
			var query = new GetAccountByImeiQuery(imei);
			var result = await _mediator.Send(query);
			return Ok(result);
		}

		[HttpGet("/api/account/mutipleImei{imei}")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		public async Task<ActionResult<bool>> GetMultipleImei(string imei)
		{
			var query = new GetAccountMultipleImeiQuery(imei);
			var result = await _mediator.Send(query);
			return Ok(result);
		}
		[HttpGet("/api/account/mutipleRole")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		public async Task<ActionResult<bool>> GetMulipleRole([FromQuery] GetAccountMultipleRoleQuery queries)
		{
			var result = await _mediator.Send(queries);
			return Ok(result);
		}

		[HttpPatch]
		[ProducesResponseType(StatusCodes.Status200OK)]
		public async Task<ActionResult<bool>> UpdatePatch([FromBody] UpdateAccountPatchCommand command)
		{
			var result = await _mediator.Send(command);
			return Ok(result);
		}
	}
}
