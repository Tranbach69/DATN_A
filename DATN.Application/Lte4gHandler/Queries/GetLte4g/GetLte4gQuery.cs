using DATN.Application.Mapper;
using DATN.Infastructure.Repositories.Lte4gRepository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DATN.Application.Lte4gHandler.Queries.GetLte4g
{
    public class GetLte4gQuery : IRequest<GetLte4gResponse>
    {
        public int Id { get; set; }

        public GetLte4gQuery(int id)
        {
            Id = id;
        }
    }
    public class GetLte4gResponse
    {
        public int Id { get; set; }
        public string MacAddress { get; set; }
        public int Lte4gOfDeviceId { get; set; }
        public string NetworkProvider { get; set; }
        public string NetworkMode { get; set; }
        public string SystemMode { get; set; }
        public string OperationMode { get; set; }
        public string MobileCountryMode { get; set; }
        public string MobileNetworkMode { get; set; }
        public string LocationArea { get; set; }
        public string ServiceCellId { get; set; }
        public string FregBand { get; set; }
        public string Current4gData { get; set; }
        public string SimCardStatus { get; set; }
        public string SimCardType { get; set; }
        public string SimCardState { get; set; }
        public string SimCardPhone { get; set; }
        public string Rssi4g { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime TimingCreate { get; set; }
        public DateTime TimingUpdate { get; set; }
        public DateTime TimingDelete { get; set; }
    }

    public class GetLte4gQueryHandler : IRequestHandler<GetLte4gQuery, GetLte4gResponse>
    {
        private readonly ILte4gRepository _Lte4gRepository;

        public GetLte4gQueryHandler(ILte4gRepository lte4gRepository)
        {
            _Lte4gRepository = lte4gRepository;
        }

        public async Task<GetLte4gResponse> Handle(GetLte4gQuery request, CancellationToken cancellationToken)
        {
            var entity = await _Lte4gRepository.BGetByIdAsync(request.Id);
            var result = Lte4gMapper.Mapper.Map<GetLte4gResponse>(entity);
            return result;

        }
    }
}
