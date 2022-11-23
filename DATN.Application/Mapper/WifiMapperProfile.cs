using AutoMapper;
using DATN.Application.WifiHandler.Commands.CreateWifi;
using DATN.Application.WifiHandler.Commands.UpdateWifi;
using DATN.Application.WifiHandler.Queries.GetWifi;
using DATN.Application.WifiHandler.Queries.GetWifiPaging;
using DATN.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DATN.Application.Mapper
{
	internal class WifiMapperProfile: Profile
    {
        public WifiMapperProfile()
        {
            CreateMap<Wifi, CreateWifiCommand>().ReverseMap();
            CreateMap<Wifi, UpdateWifiCommand>().ReverseMap();
            CreateMap<Wifi, GetWifiResponse>().ReverseMap();
            CreateMap<Wifi, GetWifiPagingResponse>().ReverseMap();
        }
    }
}
