using DATN.Application.EthernetHandler.Commands.CreateEthernet;
using DATN.Application.EthernetHandler.Commands.DeleteEthernet;
using DATN.Application.EthernetHandler.Commands.UpdateEthernet;
using DATN.Application.EthernetHandler.Queries.GetEthernet;

using DATN.Application.EthernetHandler.Queries.GetEthernetPaging;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace DATN.Api.Controllers
{
	[Route("api/ethernet")]
	[ApiController]
	public class EthernetController : ControllerBase
	{
		private readonly IMediator _mediator;

		public EthernetController(IMediator mediator)
		{
			_mediator = mediator;
		}
		[HttpPost]
		[ProducesResponseType(StatusCodes.Status200OK)]
		public async Task<ActionResult<bool>> Create([FromBody] CreateEthernetCommand command)
		{
			var result = await _mediator.Send(command);
			return result.Succeeded ? Ok(result) : BadRequest(result);
		}

		[HttpPut]
		[ProducesResponseType(StatusCodes.Status200OK)]
		public async Task<ActionResult<bool>> Update([FromBody] UpdateEthernetCommand command)
		{
			var result = await _mediator.Send(command);
			return result.Succeeded ? Ok(result) : BadRequest(result);
		}
		[HttpPatch]
		[ProducesResponseType(StatusCodes.Status200OK)]
		public async Task<ActionResult<bool>> UpdatePatch([FromBody] UpdateEthernetPatchCommand command)
		{
			var result = await _mediator.Send(command);
			return result.Succeeded ? Ok(result) : BadRequest(result);
		}

		[HttpGet("{imei}")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		public async Task<ActionResult<bool>> Get(string imei)
		{
			var query = new GetEthernetQuery(imei);
			var result = await _mediator.Send(query);
			return Ok(result);
		}


		[HttpGet]
		[ProducesResponseType(StatusCodes.Status200OK)]
		public async Task<ActionResult<bool>> Get([FromQuery] GetEthernetPagingQuery queries)
		{
			var result = await _mediator.Send(queries);
			return result.Succeeded ? Ok(result) : BadRequest(result);
		}

		[HttpDelete("{imei}")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		public async Task<ActionResult<bool>> Delete(string imei)
		{
			var query = new DeleteEthernetCommand(imei);
			var result = await _mediator.Send(query);
			return result.Succeeded ? Ok(result) : BadRequest(result);
		}
	}
}
