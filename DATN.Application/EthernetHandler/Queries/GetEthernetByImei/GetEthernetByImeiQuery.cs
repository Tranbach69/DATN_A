using DATN.Application.Mapper;
using DATN.Infastructure.Repositories.EthernetRepository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DATN.Application.EthernetHandler.Queries.GetEthernetByImei
{
    public class GetEthernetByImeiQuery : IRequest<GetEthernetByImeiResponse>
    {
        public string Imei { get; set; }

        public GetEthernetByImeiQuery(string imei)
        {
            Imei = imei;
        }
    }
    public class GetEthernetByImeiResponse
    {
        public int Id { get; set; }
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

    public class GetEthernetQueryHandler : IRequestHandler<GetEthernetByImeiQuery, GetEthernetByImeiResponse>
    {
        private readonly IEthernetRepository _ethernetRepository;

        public GetEthernetQueryHandler(IEthernetRepository ethernetRepository)
        {
            _ethernetRepository = ethernetRepository;
        }

        public async Task<GetEthernetByImeiResponse> Handle(GetEthernetByImeiQuery request, CancellationToken cancellationToken)
        {
            var entity = await _ethernetRepository.BGetByImeiAsync(request.Imei);
            var result = EthernetMapper.Mapper.Map<GetEthernetByImeiResponse>(entity);
            return result;

        }
    }
}
