using AutoMapper;
using DATN.Application.EthernetHandler.Commands.CreateEthernet;
using DATN.Application.EthernetHandler.Commands.UpdateEthernet;
using DATN.Application.EthernetHandler.Queries.GetEthernet;
using DATN.Application.EthernetHandler.Queries.GetEthernetPaging;
using DATN.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DATN.Application.Mapper
{
    public class EthernetMapperProfile : Profile
    {
        public EthernetMapperProfile()
        {
			CreateMap<Ethernet, CreateEthernetCommand>().ReverseMap();
			CreateMap<Ethernet, UpdateEthernetCommand>().ReverseMap();
			CreateMap<Ethernet, GetEthernetResponse>().ReverseMap();
            CreateMap<Ethernet, GetEthernetPagingResponse>().ReverseMap();

        }
    }
}
