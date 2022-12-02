using DATN.Application.Mapper;
using DATN.Infastructure.Repositories.AccountRepository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DATN.Application.AccountHandler.Queries.GetAccount
{
    public class GetAccountQuery : IRequest<GetAccountResponse>
    {
        public int Id { get; set; }

        public GetAccountQuery(int id)
        {
            Id = id;
        }
    }
    public class GetAccountResponse
    {
        public string Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Permission { get; set; }

    }

    public class GetAccountQueryHandler : IRequestHandler<GetAccountQuery, GetAccountResponse>
    {
        private readonly IAccountRepository _accRepository;

        public GetAccountQueryHandler(IAccountRepository accRepository)
        {
            _accRepository = accRepository;
        }

        public async Task<GetAccountResponse> Handle(GetAccountQuery request, CancellationToken cancellationToken)
        {
            var entity = await _accRepository.BGetByIdAsync(request.Id);
            var result = AccountMapper.Mapper.Map<GetAccountResponse>(entity);
            return result;

        }
    }
}
