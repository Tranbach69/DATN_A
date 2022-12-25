using DATN.Application.Mapper;
using DATN.Infastructure.Repositories.AccountRepository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DATN.Application.AccountHandler.Queries.GetAccountByImei
{
    public class GetAccountByImeiQuery : IRequest<GetAccountByImeiResponse>
    {
        public string Imei { get; set; }

        public GetAccountByImeiQuery(string imei)
        {
            Imei = imei;
        }
    }
    public class GetAccountByImeiResponse
    {
        public int Id { get; set; }
        public int Role { get; set; }
        public string Imei { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime TimingCreate { get; set; }
        public DateTime TimingUpdate { get; set; }
        public DateTime TimingDelete { get; set; }
    }

    public class GetAccountQueryHandler : IRequestHandler<GetAccountByImeiQuery, GetAccountByImeiResponse>
    {
        private readonly IAccountRepository _accountRepository;

        public GetAccountQueryHandler(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }

        public async Task<GetAccountByImeiResponse> Handle(GetAccountByImeiQuery request, CancellationToken cancellationToken)
        {
            var entity = await _accountRepository.BGetByImeiAsync(request.Imei);
            var result = AccountMapper.Mapper.Map<GetAccountByImeiResponse>(entity);
            
            return result;

        }
    }
}
