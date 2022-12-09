
using DATN.Application.WifiHandler.Commands.CreateWifi;
using DATN.Application.WifiHandler.Commands.DeleteWifi;
using DATN.Application.WifiHandler.Commands.UpdateWifi;
using DATN.Application.WifiHandler.Queries.GetWifi;
using DATN.Application.WifiHandler.Queries.GetWifiPaging;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace DATN.Api.Controllers
{
	[Route("api/wifi")]
	[ApiController]
	public class WifiController : ControllerBase
	{
		private readonly IMediator _mediator;

		public WifiController(IMediator mediator)
		{
			_mediator = mediator;
		}
		[HttpPost]
		[ProducesResponseType(StatusCodes.Status200OK)]
		public async Task<ActionResult<bool>> Create([FromBody] CreateWifiCommand command)
		{
			var result = await _mediator.Send(command);
			return result.Succeeded ? Ok(result) : BadRequest(result);
		}

		[HttpPut]
		[ProducesResponseType(StatusCodes.Status200OK)]
		public async Task<ActionResult<bool>> Update([FromBody] UpdateWifiCommand command)
		{
			var result = await _mediator.Send(command);
			return result.Succeeded ? Ok(result) : BadRequest(result);
		}	
		[HttpPatch]
		[ProducesResponseType(StatusCodes.Status200OK)]
		public async Task<ActionResult<bool>> UpdatePatch([FromBody] UpdateWifiPatchCommand command)
		{
			var result = await _mediator.Send(command);
			return result.Succeeded ? Ok(result) : BadRequest(result);
		}

		[HttpGet("{imei}")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		public async Task<ActionResult<bool>> Get(string imei)
		{
			var query = new GetWifiQuery(imei);
			var result = await _mediator.Send(query);
			return Ok(result);
		}


		[HttpGet]
		[ProducesResponseType(StatusCodes.Status200OK)]
		public async Task<ActionResult<bool>> Get([FromQuery] GetWifiPagingQuery queries)
		{
			var result = await _mediator.Send(queries);
			return result.Succeeded ? Ok(result) : BadRequest(result);
		}

		[HttpDelete("{imei}")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		public async Task<ActionResult<bool>> Delete(string imei)
		{
			var query = new DeleteWifiCommand(imei);
			var result = await _mediator.Send(query);
			return result.Succeeded ? Ok(result) : BadRequest(result);
		}
	}
}
