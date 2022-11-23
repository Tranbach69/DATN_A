using DATN.Application.Mapper;
using DATN.Infastructure.Repositories.AccountAdminRepository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DATN.Application.AccountAdminHandler.Queries.GetAccountAdmin
{
    public class GetAccountAdminQuery : IRequest<GetAccountAdminResponse>
    {
        public int Id { get; set; }

        public GetAccountAdminQuery(int id)
        {
            Id = id;
        }
    }
    public class GetAccountAdminResponse
    {
        public string Id { get; set; }      
        public string UserName { get; set; }
        public string Password { get; set; }
   
    }

    public class GetAccountAdminQueryHandler : IRequestHandler<GetAccountAdminQuery, GetAccountAdminResponse>
    {
        private readonly IAccountAdminRepository _accAdRepository;

        public GetAccountAdminQueryHandler(IAccountAdminRepository accAdRepository)
        {
            _accAdRepository = accAdRepository;
        }

        public async Task<GetAccountAdminResponse> Handle(GetAccountAdminQuery request, CancellationToken cancellationToken)
        {
            var entity = await _accAdRepository.BGetByIdAsync(request.Id);
            var result = AccountAdminMapper.Mapper.Map<GetAccountAdminResponse>(entity);
            return result;

        }
    }
}
