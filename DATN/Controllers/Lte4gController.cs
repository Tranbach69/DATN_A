using DATN.Application.Lte4gHandler.Commands.CreateLte4g;
using DATN.Application.Lte4gHandler.Commands.DeleteLte4g;
using DATN.Application.Lte4gHandler.Commands.UpdateLte4g;
using DATN.Application.Lte4gHandler.Queries.GetLte4g;

using DATN.Application.Lte4gHandler.Queries.GetLte4gPaging;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace DATN.Api.Controllers
{
	[Route("api/lte4g")]
	[ApiController]
	public class Lte4gController : ControllerBase
	{
		private readonly IMediator _mediator;

		public Lte4gController(IMediator mediator)
		{
			_mediator = mediator;
		}
		[HttpPost]
		[ProducesResponseType(StatusCodes.Status200OK)]
		public async Task<ActionResult<bool>> Create([FromBody] CreateLte4gCommand command)
		{
			var result = await _mediator.Send(command);
			return result.Succeeded ? Ok(result) : BadRequest(result);
		}

		[HttpPut]
		[ProducesResponseType(StatusCodes.Status200OK)]
		public async Task<ActionResult<bool>> ChangePassword([FromBody] UpdateLte4gCommand command)
		{
			var result = await _mediator.Send(command);
			return result.Succeeded ? Ok(result) : BadRequest(result);
		}

		[HttpGet("{imei}")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		public async Task<ActionResult<bool>> Get(string imei)
		{
			var query = new GetLte4gQuery(imei);
			var result = await _mediator.Send(query);
			return Ok(result);
		}

		[HttpGet]
		[ProducesResponseType(StatusCodes.Status200OK)]
		public async Task<ActionResult<bool>> Get([FromQuery] GetLte4gPagingQuery queries)
		{
			var result = await _mediator.Send(queries);
			return result.Succeeded ? Ok(result) : BadRequest(result);
		}

		[HttpDelete("{imei}")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		public async Task<ActionResult<bool>> Delete(string imei)
		{
			var query = new DeleteLte4gCommand(imei);
			var result = await _mediator.Send(query);
			return result.Succeeded ? Ok(result) : BadRequest(result);
		}
		[HttpPatch]
		[ProducesResponseType(StatusCodes.Status200OK)]
		public async Task<ActionResult<bool>> UpdatePatch([FromBody] UpdateLte4gPatchCommand command)
		{
			var result = await _mediator.Send(command);
			return result.Succeeded ? Ok(result) : BadRequest(result);
		}
	}
}
