using DATN.Application.Mapper;
using DATN.Application.Models;
using DATN.Infastructure.Repositories.AccountRepository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DATN.Application.AccountHandler.Queries.GetAccountByMultipleImei
{
    public class GetAccountMultipleImeiQuery : IRequest<BResult<BPaging<GetAccountMultipleImeiResponse>>>
    {
        public string Imei { get; set; }

        public GetAccountMultipleImeiQuery(string imei)
        {
            Imei = imei;
        }
    }
    public class GetAccountMultipleImeiResponse
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

    public class GetAccountMultipleImeQueryHandler : IRequestHandler<GetAccountMultipleImeiQuery, BResult<BPaging<GetAccountMultipleImeiResponse>>>
    {
        private readonly IAccountRepository _accountRepository;

        public GetAccountMultipleImeQueryHandler(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }

        public async Task<BResult<BPaging<GetAccountMultipleImeiResponse>>> Handle(GetAccountMultipleImeiQuery request, CancellationToken cancellationToken)
        {
            var entity = await _accountRepository.BGetMultipleImeiAsync(request.Imei);
            var items = AccountMapper.Mapper.Map<List<GetAccountMultipleImeiResponse>>(entity);
            var total = await _accountRepository.BGetTotalImeiAsync(request.Imei);
            var result = new BPaging<GetAccountMultipleImeiResponse>()
            {
                Items = items,
                TotalItems = total,
            };
            return BResult<BPaging<GetAccountMultipleImeiResponse>>.Success(result);

        }
    }
}
