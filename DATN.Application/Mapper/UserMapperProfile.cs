using AutoMapper;
using DATN.Application.UserHandler.Commands.CreateUser;
using DATN.Application.UserHandler.Commands.UpdateUser;
using DATN.Application.UserHandler.Queries.GetUser;
using DATN.Application.UserHandler.Queries.GetUserByImei;
using DATN.Application.UserHandler.Queries.GetUserPaging;
using DATN.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DATN.Application.Mapper
{
	internal class UserMapperProfile: Profile
    {
        public UserMapperProfile()
        {
            CreateMap<User, CreateUserCommand>().ReverseMap();
            CreateMap<User, UpdateUserCommand>().ReverseMap();
            CreateMap<User, GetUserResponse>().ReverseMap();
            CreateMap<User, GetUserPagingResponse>().ReverseMap();
            CreateMap<User, GetUserByImeiResponse>().ReverseMap();
        }
    }
}
