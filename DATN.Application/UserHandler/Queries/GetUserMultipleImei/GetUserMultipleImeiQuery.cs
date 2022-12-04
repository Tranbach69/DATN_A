using DATN.Application.Mapper;
using DATN.Application.Models;
using DATN.Infastructure.Repositories.UserRepository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DATN.Application.UserHandler.Queries.GetUserByMultipleImei
{
    public class GetUserMultipleImeiQuery : IRequest<BResult<BPaging<GetUserMultipleImeiResponse>>>
    {
        public string Imei { get; set; }

        public GetUserMultipleImeiQuery(string imei)
        {
            Imei = imei;
        }
    }
    public class GetUserMultipleImeiResponse
    {
        public int Id { get; set; }
        public int Age { get; set; }
        public string Phone { get; set; }
        public string Imei { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime TimingCreate { get; set; }
        public DateTime TimingUpdate { get; set; }
        public DateTime TimingDelete { get; set; }
    }

    public class GetUserMultipleImeQueryHandler : IRequestHandler<GetUserMultipleImeiQuery, BResult<BPaging<GetUserMultipleImeiResponse>>>
    {
        private readonly IUserRepository _userRepository;

        public GetUserMultipleImeQueryHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<BResult<BPaging<GetUserMultipleImeiResponse>>> Handle(GetUserMultipleImeiQuery request, CancellationToken cancellationToken)
        {
            var entity = await _userRepository.BGetMultipleImeiAsync(request.Imei);
            var items = UserMapper.Mapper.Map<List<GetUserMultipleImeiResponse>>(entity);
            var total = await _userRepository.BGetTotalImeiAsync(request.Imei);
            var result = new BPaging<GetUserMultipleImeiResponse>()
            {
                Items = items,
                TotalItems = total,
            };
            return BResult<BPaging<GetUserMultipleImeiResponse>>.Success(result);

        }
    }
}
