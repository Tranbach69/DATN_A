using DATN.Application.Mapper;
using DATN.Application.Models;
using DATN.Core.Entities;
using DATN.Infastructure.Repositories.Lte4gRepository;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace DATN.Application.Lte4gHandler.Commands.CreateLte4g
{
	public class CreateLte4gCommand : IRequest<BResult>
	{
        public string Imei { get; set; }
		public int CardStatus { get; set; }
		public int AppType { get; set; }
		public int AppState { get; set; }
		public int Pin { get; set; }
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
		public int Rssi4G { get; set; }
		public int NetworkMode { get; set; }
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
			var result = await _Lte4gRepository.BAddAsync(entity);
			if (result == null)
			{
				if (request.Imei == "")
				{
					return BResult.Failure("Imei phải có giá trị");
				}
				else return BResult.Failure("Không Thành Công, Xem Lại Thông Tin Đã nhập: imei có bị trùng không...");

			}
			return BResult.Success();
		}
	}
}
