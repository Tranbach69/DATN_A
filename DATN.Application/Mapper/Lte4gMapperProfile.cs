using AutoMapper;
using DATN.Application.Lte4gHandler.Commands.CreateLte4g;
using DATN.Application.Lte4gHandler.Commands.UpdateLte4g;
using DATN.Application.Lte4gHandler.Queries.GetLte4g;
using DATN.Application.Lte4gHandler.Queries.GetLte4gByImei;
using DATN.Application.Lte4gHandler.Queries.GetLte4gPaging;
using DATN.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DATN.Application.Mapper
{
	internal class Lte4gMapperProfile: Profile
    {
        public Lte4gMapperProfile()
        {
            CreateMap<Lte4g, CreateLte4gCommand>().ReverseMap();
            CreateMap<Lte4g, UpdateLte4gCommand>().ReverseMap();
            CreateMap<Lte4g, GetLte4gResponse>().ReverseMap();
            CreateMap<Lte4g, GetLte4gPagingResponse>().ReverseMap();
            CreateMap<Lte4g, GetLte4gByImeiResponse>().ReverseMap();
        }
    }
}
