using AutoMapper;
using DATN.Application.GpsHandler.Commands.CreateGps;
using DATN.Application.GpsHandler.Commands.UpdateGps;
using DATN.Application.GpsHandler.Queries.GetGps;
using DATN.Application.GpsHandler.Queries.GetGpsByImei;
using DATN.Application.GpsHandler.Queries.GetGpsPaging;
using DATN.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DATN.Application.Mapper
{
	internal class GpsMapperProfile : Profile
    {
        public GpsMapperProfile()
        {
			CreateMap<Gps, CreateGpsCommand>().ReverseMap();
			CreateMap<Gps, UpdateGpsCommand>().ReverseMap();
			CreateMap<Gps, GetGpsResponse>().ReverseMap();
            CreateMap<Gps, GetGpsPagingResponse>().ReverseMap();
            CreateMap<Account, GetGpsByImeiResponse>().ReverseMap();
        }
    }
}
