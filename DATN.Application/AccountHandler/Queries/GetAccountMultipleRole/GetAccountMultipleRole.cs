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

namespace DATN.Application.AccountHandler.Queries.GetAccountMultipleRole
{
    public class GetAccountMultipleRoleQuery : IRequest<BResult<BPaging<GetAccountMultipleRoleResponse>>>
    {
        public int Role { get; set; }
        public int Skip { get; set; }
        public int PageSize { get; set; }

        //public GetAccountMultipleRoleQuery(int role)
        //{
        //    Role = role;

        //}
    }
    public class GetAccountMultipleRoleResponse
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

    public class GetAccountMultipleRoleQueryHandler : IRequestHandler<GetAccountMultipleRoleQuery, BResult<BPaging<GetAccountMultipleRoleResponse>>>
    {
        private readonly IAccountRepository _accountRepository;

        public GetAccountMultipleRoleQueryHandler(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }

        public async Task<BResult<BPaging<GetAccountMultipleRoleResponse>>> Handle(GetAccountMultipleRoleQuery request, CancellationToken cancellationToken)
        {
            var entity = await _accountRepository.GetMultipleRoleAsync(request.Role, request.Skip, request.PageSize);
            var items = AccountMapper.Mapper.Map<List<GetAccountMultipleRoleResponse>>(entity);
            var total = await _accountRepository.GetTotalRoleAsync(request.Role);
            var result = new BPaging<GetAccountMultipleRoleResponse>()
            {
                Items = items,
                TotalItems = total,
            };
            return BResult<BPaging<GetAccountMultipleRoleResponse>>.Success(result);

        }
    }
}
