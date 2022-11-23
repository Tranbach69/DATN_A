using DATN.Application.Mapper;
using DATN.Application.Models;
using DATN.Infastructure.Repositories.AccountAdminRepository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DATN.Application.AccountAdminHandler.Queries.GetAccountAdminPaging
{
    public class GetAccountAdminPagingQuery : IRequest<BResult<BPaging<GetAccountAdminPagingResponse>>>
    {
        public int Skip { get; set; }
        public int PageSize { get; set; }
    }
    public class GetAccountAdminPagingResponse
    {
        public string Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        
    }
    public class GetAccountAdminPagingQueryHandler : IRequestHandler<GetAccountAdminPagingQuery, BResult<BPaging<GetAccountAdminPagingResponse>>>
    {
        private readonly IAccountAdminRepository _accAdRepository;

        public GetAccountAdminPagingQueryHandler(IAccountAdminRepository accAdRepository)
        {
            _accAdRepository = accAdRepository;
        }
        public async Task<BResult<BPaging<GetAccountAdminPagingResponse>>> Handle(GetAccountAdminPagingQuery request, CancellationToken cancellationToken)
        {
            var entities = await _accAdRepository.BGetPagingAsync(request.Skip, request.PageSize);
            var items = AccountAdminMapper.Mapper.Map<List<GetAccountAdminPagingResponse>>(entities);
            var total = await _accAdRepository.BGetTotalAsync();

            var result = new BPaging<GetAccountAdminPagingResponse>()
            {
                Items = items,

                TotalItems = total,
            };
            return BResult<BPaging<GetAccountAdminPagingResponse>>.Success(result);
        }
    }
}
