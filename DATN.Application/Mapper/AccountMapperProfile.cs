using AutoMapper;
using DATN.Application.AccountHandler.Commands.CreateAccount;
using DATN.Application.AccountHandler.Commands.UpdateAccount;
using DATN.Application.AccountHandler.Queries.GetAccount;
using DATN.Application.AccountHandler.Queries.GetAccountByImei;
using DATN.Application.AccountHandler.Queries.GetAccountPaging;
using DATN.Core.Entities;

namespace DATN.Application.Mapper
{
    public class AccountMapperProfile : Profile
    {
        public AccountMapperProfile()
        {
            CreateMap<Account, CreateAccountCommand>().ReverseMap();
            CreateMap<Account, UpdateAccountCommand>().ReverseMap();
            CreateMap<Account, GetAccountResponse>().ReverseMap();
            CreateMap<Account, GetAccountPagingResponse>().ReverseMap();
            CreateMap<Account, GetAccountByImeiResponse>().ReverseMap();
        }
    }
}
