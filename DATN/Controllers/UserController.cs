using DATN.Application.UserHandler.Commands.CreateUser;
using DATN.Application.UserHandler.Commands.DeleteUser;
using DATN.Application.UserHandler.Commands.UpdateUser;
using DATN.Application.UserHandler.Queries.GetUser;
using DATN.Application.UserHandler.Queries.GetUserByImei;
using DATN.Application.UserHandler.Queries.GetUserByMultipleImei;
using DATN.Application.UserHandler.Queries.GetUserPaging;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace DATN.Api.Controllers
{
	[Route("api/user")]
	[ApiController]
	public class UserController : ControllerBase
	{
		private readonly IMediator _mediator;

		public UserController(IMediator mediator)
		{
			_mediator = mediator;
		}
		[HttpPost]
		[ProducesResponseType(StatusCodes.Status200OK)]
		public async Task<ActionResult<bool>> Create([FromBody] CreateUserCommand command)
		{
			var result = await _mediator.Send(command);
			return Ok(result);
		}

		[HttpPut("changepass")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		public async Task<ActionResult<bool>> ChangePassword([FromBody] UpdateUserCommand command)
		{
			var result = await _mediator.Send(command);
			return result.Succeeded ? Ok(result) : BadRequest(result);
		}

		[HttpGet("{id:int}")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		public async Task<ActionResult<bool>> Get(int id)
		{
			var query = new GetUserQuery(id);
			var result = await _mediator.Send(query);
			return Ok(result);
		}
		[HttpGet("/api/user/imei{imei}")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		public async Task<ActionResult<bool>> Get(string imei)
		{
			var query = new GetUserByImeiQuery(imei);
			var result = await _mediator.Send(query);
			return Ok(result);
		}
		[HttpGet("/api/user/mutipleImei{imei}")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		public async Task<ActionResult<bool>> GetMultipleImei(string imei)
		{
			var query = new GetUserMultipleImeiQuery(imei);
			var result = await _mediator.Send(query);
			return Ok(result);
		}


		[HttpGet]
		[ProducesResponseType(StatusCodes.Status200OK)]
		public async Task<ActionResult<bool>> Get([FromQuery] GetUserPagingQuery queries)
		{
			var result = await _mediator.Send(queries);
			return Ok(result);
		}

		[HttpDelete("{id:int}")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		public async Task<ActionResult<bool>> Delete(int id)
		{
			var query = new DeleteUserCommand(id);
			var result = await _mediator.Send(query);
			return Ok(result);
		}
		[HttpPatch]
		[ProducesResponseType(StatusCodes.Status200OK)]
		public async Task<ActionResult<bool>> UpdatePatch([FromBody] UpdateUserPatchCommand command)
		{
			var result = await _mediator.Send(command);
			return Ok(result);
		}
	}
}
