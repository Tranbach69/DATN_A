using DATN.Application.Mapper;
using DATN.Application.Models;
using DATN.Core.Entities;
using DATN.Infastructure.Repositories.UserRepository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DATN.Application.UserHandler.Queries.GetUserPaging
{
    public class GetUserPagingQuery : IRequest<BResult<BPaging<GetUserPagingResponse>>>
    {
        public int Skip { get; set; }
        public int PageSize { get; set; }
    }
    public class GetUserPagingResponse
    {
        public int Id { get; set; }
        public string MacAddress { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public IList<Device> Devices { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime TimingCreate { get; set; }
        public DateTime TimingUpdate { get; set; }
        public DateTime TimingDelete { get; set; }
    }
    public class GetUserPagingQueryHandler : IRequestHandler<GetUserPagingQuery, BResult<BPaging<GetUserPagingResponse>>>
    {
        private readonly IUserRepository _UserRepository;

        public GetUserPagingQueryHandler(IUserRepository UserRepository)
        {
            _UserRepository = UserRepository;
        }
        public async Task<BResult<BPaging<GetUserPagingResponse>>> Handle(GetUserPagingQuery request, CancellationToken cancellationToken)
        {
            var entities = await _UserRepository.BGetPagingAsync(request.Skip, request.PageSize);
            var items = UserMapper.Mapper.Map<List<GetUserPagingResponse>>(entities);
            var total = await _UserRepository.BGetTotalAsync();

            var result = new BPaging<GetUserPagingResponse>()
            {
                Items = items,

                TotalItems = total,
            };
            return BResult<BPaging<GetUserPagingResponse>>.Success(result);
        }
    }
}
