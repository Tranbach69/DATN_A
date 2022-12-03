using DATN.Application.DeviceHandler.Commands.CreateDevice;
using DATN.Application.DeviceHandler.Commands.DeleteDevice;
using DATN.Application.DeviceHandler.Commands.UpdateDevice;
using DATN.Application.DeviceHandler.Queries.GetAllDeviceUser;

using DATN.Application.DeviceHandler.Queries.GetDevice;
using DATN.Application.DeviceHandler.Queries.GetDeviceByImei;
using DATN.Application.DeviceHandler.Queries.GetDevicePaging;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace DATN.Api.Controllers
{
	[Route("api/device")]
	[ApiController]
	public class DeviceController : ControllerBase
	{
		private readonly IMediator _mediator;

		public DeviceController(IMediator mediator)
		{
			_mediator = mediator;
		}
		[HttpPost]
		[ProducesResponseType(StatusCodes.Status200OK)]
		public async Task<ActionResult<bool>> Create([FromBody] CreateDeviceCommand command)
		{
			var result = await _mediator.Send(command);
			return Ok(result);
		}

		[HttpPut]
		[ProducesResponseType(StatusCodes.Status200OK)]
		public async Task<ActionResult<bool>> Update([FromBody] UpdateDeviceCommand command)
		{
			var result = await _mediator.Send(command);
			return Ok(result);
		}
		[HttpGet("deviceUserList")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		public async Task<ActionResult<bool>> GetAllDeviceUserList()
		{
			var result = await _mediator.Send(new GetDevicesWithUserInfoQuery());
			return Ok(result);
		}

		[HttpGet("{id:int}")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		public async Task<ActionResult<bool>> Get(int id)
		{
			var query = new GetDeviceQuery(id);
			var result = await _mediator.Send(query);
			return Ok(result);
		}
		[HttpGet("/api/device/imei{imei}")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		public async Task<ActionResult<bool>> Get(string imei)
		{
			var query = new GetDeviceByImeiQuery(imei);
			var result = await _mediator.Send(query);
			return Ok(result);
		}


		[HttpGet]
		[ProducesResponseType(StatusCodes.Status200OK)]
		public async Task<ActionResult<bool>> Get([FromQuery] GetDevicePagingQuery queries)
		{
			var result = await _mediator.Send(queries);
			return Ok(result);
		}

		[HttpDelete("{id:int}")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		public async Task<ActionResult<bool>> Delete(int id)
		{
			var query = new DeleteDeviceCommand(id);
			var result = await _mediator.Send(query);
			return Ok(result);
		}
		[HttpPatch]
		[ProducesResponseType(StatusCodes.Status200OK)]
		public async Task<ActionResult<bool>> UpdatePatch([FromBody] UpdateDevicePatchCommand command)
		{
			var result = await _mediator.Send(command);
			return Ok(result);
		}
	}
}
