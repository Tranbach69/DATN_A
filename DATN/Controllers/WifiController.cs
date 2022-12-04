
using DATN.Application.WifiHandler.Commands.CreateWifi;
using DATN.Application.WifiHandler.Commands.DeleteWifi;
using DATN.Application.WifiHandler.Commands.UpdateWifi;
using DATN.Application.WifiHandler.Queries.GetWifi;
using DATN.Application.WifiHandler.Queries.GetWifiByImei;
using DATN.Application.WifiHandler.Queries.GetWifiByMultipleImei;
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
			return Ok(result);
		}

		[HttpPut]
		[ProducesResponseType(StatusCodes.Status200OK)]
		public async Task<ActionResult<bool>> Update([FromBody] UpdateWifiCommand command)
		{
			var result = await _mediator.Send(command);
			return Ok(result);
		}	
		[HttpPatch]
		[ProducesResponseType(StatusCodes.Status200OK)]
		public async Task<ActionResult<bool>> UpdatePatch([FromBody] UpdateWifiPatchCommand command)
		{
			var result = await _mediator.Send(command);
			return Ok(result);
		}

		[HttpGet("{id:int}")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		public async Task<ActionResult<bool>> Get(int id)
		{
			var query = new GetWifiQuery(id);
			var result = await _mediator.Send(query);
			return Ok(result);
		}
		[HttpGet("/api/wifi/imei{imei}")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		public async Task<ActionResult<bool>> Get(string imei)
		{
			var query = new GetWifiByImeiQuery(imei);
			var result = await _mediator.Send(query);
			return Ok(result);
		}
		[HttpGet("/api/wifi/mutipleImei{imei}")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		public async Task<ActionResult<bool>> GetMultipleImei(string imei)
		{
			var query = new GetWifiMultipleImeiQuery(imei);
			var result = await _mediator.Send(query);
			return Ok(result);
		}


		[HttpGet]
		[ProducesResponseType(StatusCodes.Status200OK)]
		public async Task<ActionResult<bool>> Get([FromQuery] GetWifiPagingQuery queries)
		{
			var result = await _mediator.Send(queries);
			return Ok(result);
		}

		[HttpDelete("{id:int}")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		public async Task<ActionResult<bool>> Delete(int id)
		{
			var query = new DeleteWifiCommand(id);
			var result = await _mediator.Send(query);
			return Ok(result);
		}
	}
}
