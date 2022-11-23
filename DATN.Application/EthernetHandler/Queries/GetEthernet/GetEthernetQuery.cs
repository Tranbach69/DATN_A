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
        public int Id { get; set; }

        public GetEthernetQuery(int id)
        {
            Id = id;
        }
    }
    public class GetEthernetResponse
    {
        public int Id { get; set; }
        public string MacAddress { get; set; }

        public int EthernetOfDeviceId { get; set; }
        public string DriverType { get; set; }
        public string LanCtrl { get; set; }
        public string LanMode { get; set; }
        public string EthernetIp { get; set; }
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
            var entity = await _EthernetRepository.BGetByIdAsync(request.Id);
            var result = EthernetMapper.Mapper.Map<GetEthernetResponse>(entity);
            return result;

        }
    }
}
