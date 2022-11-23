using AutoMapper;
using DATN.Application.AccountAdminHandler.Commands.CreateAccountAdmin;
using DATN.Application.AccountAdminHandler.Commands.UpdateAccountAdmin;
using DATN.Application.AccountAdminHandler.Queries.GetAccountAdmin;
using DATN.Application.AccountAdminHandler.Queries.GetAccountAdminPaging;
using DATN.Core.Entities;

namespace DATN.Application.Mapper
{
    public class AccountAdminMapperProfile : Profile
    {
        public AccountAdminMapperProfile()
        {
            CreateMap<AccountAdmin, CreateAccountAdminCommand>().ReverseMap();
            CreateMap<AccountAdmin, UpdateAccountAdminCommand>().ReverseMap();
            CreateMap<AccountAdmin, GetAccountAdminResponse>().ReverseMap();
            CreateMap<AccountAdmin, GetAccountAdminPagingResponse>().ReverseMap();
        }
    }
}
