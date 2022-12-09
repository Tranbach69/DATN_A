using DATN.Application.GpsHandler.Commands.CreateGps;
using DATN.Application.GpsHandler.Commands.DeleteGps;
using DATN.Application.GpsHandler.Commands.UpdateGps;
using DATN.Application.GpsHandler.Queries.GetGps;
using DATN.Application.GpsHandler.Queries.GetGpsPaging;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace DATN.Api.Controllers
{
	[Route("api/gps")]
	[ApiController]
	public class GpsController : ControllerBase
	{
		private readonly IMediator _mediator;

		public GpsController(IMediator mediator)
		{
			_mediator = mediator;
		}
		[HttpPost]
		[ProducesResponseType(StatusCodes.Status200OK)]
		public async Task<ActionResult<bool>> Create([FromBody] CreateGpsCommand command)
		{
			var result = await _mediator.Send(command);
			return result.Succeeded ? Ok(result) : BadRequest(result);
		}

		[HttpPut]
		[ProducesResponseType(StatusCodes.Status200OK)]
		public async Task<ActionResult<bool>> ChangePassword([FromBody] UpdateGpsCommand command)
		{
			var result = await _mediator.Send(command);
			return result.Succeeded ? Ok(result) : BadRequest(result);
		}

		[HttpGet("{imei}")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		public async Task<ActionResult<bool>> Get(string imei)
		{
			var query = new GetGpsQuery(imei);
			var result = await _mediator.Send(query);
			return Ok(result);
		}

		[HttpGet]
		[ProducesResponseType(StatusCodes.Status200OK)]
		public async Task<ActionResult<bool>> Get([FromQuery] GetGpsPagingQuery queries)
		{
			var result = await _mediator.Send(queries);
			return result.Succeeded ? Ok(result) : BadRequest(result);
		}

		[HttpDelete("{imei}")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		public async Task<ActionResult<bool>> Delete(string imei)
		{
			var query = new DeleteGpsCommand(imei);
			var result = await _mediator.Send(query);
			return result.Succeeded ? Ok(result) : BadRequest(result);
		}
		[HttpPatch]
		[ProducesResponseType(StatusCodes.Status200OK)]
		public async Task<ActionResult<bool>> UpdatePatch([FromBody] UpdateGpsPatchCommand command)
		{
			var result = await _mediator.Send(command);
			return result.Succeeded ? Ok(result) : BadRequest(result);
		}
	}
}
