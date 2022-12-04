﻿using DATN.Application.EthernetHandler.Commands.CreateEthernet;
using DATN.Application.EthernetHandler.Commands.DeleteEthernet;
using DATN.Application.EthernetHandler.Commands.UpdateEthernet;
using DATN.Application.EthernetHandler.Queries.GetEthernet;
using DATN.Application.EthernetHandler.Queries.GetEthernetByImei;
using DATN.Application.EthernetHandler.Queries.GetEthernetByMultipleImei;
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
			return Ok(result);
		}

		[HttpPut]
		[ProducesResponseType(StatusCodes.Status200OK)]
		public async Task<ActionResult<bool>> Update([FromBody] UpdateEthernetCommand command)
		{
			var result = await _mediator.Send(command);
			return Ok(result);
		}
		[HttpPatch]
		[ProducesResponseType(StatusCodes.Status200OK)]
		public async Task<ActionResult<bool>> UpdatePatch([FromBody] UpdateEthernetPatchCommand command)
		{
			var result = await _mediator.Send(command);
			return Ok(result);
		}

		[HttpGet("{id:int}")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		public async Task<ActionResult<bool>> Get(int id)
		{
			var query = new GetEthernetQuery(id);
			var result = await _mediator.Send(query);
			return Ok(result);
		}
		[HttpGet("/api/ethernet/imei{imei}")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		public async Task<ActionResult<bool>> Get(string imei)
		{
			var query = new GetEthernetByImeiQuery(imei);
			var result = await _mediator.Send(query);
			return Ok(result);
		}

		[HttpGet("/api/ethernet/mutipleImei{imei}")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		public async Task<ActionResult<bool>> GetMultipleImei(string imei)
		{
			var query = new GetEthernetMultipleImeiQuery(imei);
			var result = await _mediator.Send(query);
			return Ok(result);
		}

		[HttpGet]
		[ProducesResponseType(StatusCodes.Status200OK)]
		public async Task<ActionResult<bool>> Get([FromQuery] GetEthernetPagingQuery queries)
		{
			var result = await _mediator.Send(queries);
			return Ok(result);
		}

		[HttpDelete("{id:int}")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		public async Task<ActionResult<bool>> Delete(int id)
		{
			var query = new DeleteEthernetCommand(id);
			var result = await _mediator.Send(query);
			return Ok(result);
		}
	}
}
