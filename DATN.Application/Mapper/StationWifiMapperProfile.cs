using AutoMapper;
using DATN.Application.StationWifiHandler.Commands.CreateStationWifi;
using DATN.Application.StationWifiHandler.Commands.UpdateStationWifi;
using DATN.Application.StationWifiHandler.Queries.GetStationWifi;
using DATN.Application.StationWifiHandler.Queries.GetStationWifiByImei;
using DATN.Application.StationWifiHandler.Queries.GetStationWifiPaging;
using DATN.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DATN.Application.Mapper
{
    internal class StationWifiMapperProfile : Profile
    {
        public StationWifiMapperProfile()
        {
            CreateMap<StationWifi, CreateStationWifiCommand>().ReverseMap();
            CreateMap<StationWifi, UpdateStationWifiCommand>().ReverseMap();
            CreateMap<StationWifi, GetStationWifiResponse>().ReverseMap();
            CreateMap<StationWifi, GetStationWifiPagingResponse>().ReverseMap();
            CreateMap<StationWifi, GetStationWifiByImeiResponse>().ReverseMap();
        }
    }
}
