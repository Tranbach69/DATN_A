using DATN.Application.Mapper;
using DATN.Infastructure.Repositories.EthernetRepository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DATN.Application.EthernetHandler.Queries.GetEthernet
{
    public class GetEthernetQuery : IRequest<GetEthernetResponse>
    {
        public string Imei { get; set; }

        public GetEthernetQuery(string imei)
        {
            Imei = imei;
        }
    }
    public class GetEthernetResponse
    {
        public string Imei { get; set; }
        public int DriverType { get; set; }
        public int DriverEn { get; set; }
        public int BringUpdownEn { get; set; }
        public int IpStaticEn { get; set; }
        public string IpAddr { get; set; }
        public string Netmask { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime TimingCreate { get; set; }
        public DateTime TimingUpdate { get; set; }
        public DateTime TimingDelete { get; set; }
    }

    public class GetEthernetQueryHandler : IRequestHandler<GetEthernetQuery, GetEthernetResponse>
    {
        private readonly IEthernetRepository _EthernetRepository;

		public GetEthernetQueryHandler(IEthernetRepository ethernetRepository)
        {
            _EthernetRepository = ethernetRepository;
        }

        public async Task<GetEthernetResponse> Handle(GetEthernetQuery request, CancellationToken cancellationToken)
        {
            var entity = await _EthernetRepository.BGetByImeiAsync(request.Imei);
            var result = EthernetMapper.Mapper.Map<GetEthernetResponse>(entity);
            return result;

        }
    }
}
