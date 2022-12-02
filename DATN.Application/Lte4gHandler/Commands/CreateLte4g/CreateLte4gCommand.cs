using DATN.Application.Mapper;
using DATN.Application.Models;
using DATN.Core.Entities;
using DATN.Infastructure.Repositories.Lte4gRepository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DATN.Application.Lte4gHandler.Commands.CreateLte4g
{
	public class CreateLte4gCommand : IRequest<BResult>
	{
        public string Imei { get; set; }
        public string SimStatus { get; set; }
        public string SimIccid { get; set; }
        public string SimImsi { get; set; }
        public string SystemMode { get; set; }
        public string OperationMode { get; set; }
        public string MobileCountryCode { get; set; }
        public string MobileNetworkCode { get; set; }
        public string LocationAreaCode { get; set; }
        public string ServiceCellId { get; set; }
        public string FreqBand { get; set; }
        public string Current4GData { get; set; }
        public string Afrcn { get; set; }
        public string PhoneNumber { get; set; }
        public string Rssi4G { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime TimingCreate { get; set; }
        public DateTime TimingUpdate { get; set; }
        public DateTime TimingDelete { get; set; }
    }
	public class CreateLte4gCommandHandler : IRequestHandler<CreateLte4gCommand, BResult>
	{
		private readonly ILte4gRepository _Lte4gRepository;

		public CreateLte4gCommandHandler(ILte4gRepository lte4gRepository)
		{
			_Lte4gRepository = lte4gRepository;
		}

		public async Task<BResult> Handle(CreateLte4gCommand request, CancellationToken cancellationToken)
		{
			var entity = Lte4gMapper.Mapper.Map<Lte4g>(request);
			await _Lte4gRepository.BAddAsync(entity);
			return BResult.Success();
		}
	}
}
