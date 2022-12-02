using DATN.Application.Mapper;
using DATN.Application.Models;
using DATN.Core.Entities;
using DATN.Infastructure.Repositories.EthernetRepository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DATN.Application.EthernetHandler.Commands.CreateEthernet
{
	public class CreateEthernetCommand : IRequest<BResult>
	{
		public string Imei { get; set; }
		public string DriverType { get; set; }
		public string BringUpdownEn { get; set; }
		public string IpStaticEn { get; set; }
		public string IpAddr { get; set; }
		public string DriverEn { get; set; }
		public string Netmask { get; set; }
		public bool IsDeleted { get; set; }
		public DateTime TimingCreate { get; set; }
		public DateTime TimingUpdate { get; set; }
		public DateTime TimingDelete { get; set; }

	}
	public class CreateEthernetCommandHandler : IRequestHandler<CreateEthernetCommand, BResult>
	{
		private readonly IEthernetRepository _EthernetRepository;

		public CreateEthernetCommandHandler(IEthernetRepository ethernetRepository)
		{
			_EthernetRepository = ethernetRepository;
		}

		public async Task<BResult> Handle(CreateEthernetCommand request, CancellationToken cancellationToken)
		{
			var entity = EthernetMapper.Mapper.Map<Ethernet>(request);
			await _EthernetRepository.BAddAsync(entity);
			return BResult.Success();
		}
	}
}
