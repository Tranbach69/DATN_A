
using DATN.Application.StationWifiHandler.Commands.CreateStationWifi;
using DATN.Application.StationWifiHandler.Commands.DeleteStationWifi;
using DATN.Application.StationWifiHandler.Commands.UpdateStationWifi;
using DATN.Application.StationWifiHandler.Queries.GetStationWifi;
using DATN.Application.StationWifiHandler.Queries.GetStationWifiPaging;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace DATN.Api.Controllers
{
	[Route("api/stationwifi")]
	[ApiController]
	public class StationWifiController : ControllerBase
	{
		private readonly IMediator _mediator;

		public StationWifiController(IMediator mediator)
		{
			_mediator = mediator;
		}
		[HttpPost]
		[ProducesResponseType(StatusCodes.Status200OK)]
		public async Task<ActionResult<bool>> Create([FromBody] CreateStationWifiCommand command)
		{
			var result = await _mediator.Send(command);
			return Ok(result);
		}

		[HttpPut]
		[ProducesResponseType(StatusCodes.Status200OK)]
		public async Task<ActionResult<bool>> ChangePassword([FromBody] UpdateStationWifiCommand command)
		{
			var result = await _mediator.Send(command);
			return Ok(result);
		}

		[HttpGet("{id:int}")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		public async Task<ActionResult<bool>> Get(int id)
		{
			var query = new GetStationWifiQuery(id);
			var result = await _mediator.Send(query);
			return Ok(result);
		}

		[HttpGet]
		[ProducesResponseType(StatusCodes.Status200OK)]
		public async Task<ActionResult<bool>> Get([FromQuery] GetStationWifiPagingQuery queries)
		{
			var result = await _mediator.Send(queries);
			return Ok(result);
		}

		[HttpDelete("{id:int}")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		public async Task<ActionResult<bool>> Delete(int id)
		{
			var query = new DeleteStationWifiCommand(id);
			var result = await _mediator.Send(query);
			return Ok(result);
		}
		[HttpPatch]
		[ProducesResponseType(StatusCodes.Status200OK)]
		public async Task<ActionResult<bool>> UpdatePatch([FromBody] UpdateStationWifiPatchCommand command)
		{
			var result = await _mediator.Send(command);
			return Ok(result);
		}
	}
}
