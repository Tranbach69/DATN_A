using DATN.Application.Mapper;
using DATN.Infastructure.Repositories.UserRepository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DATN.Application.UserHandler.Queries.GetUserByImei
{
    public class GetUserByImeiQuery : IRequest<GetUserByImeiResponse>
    {
        public string Imei { get; set; }

        public GetUserByImeiQuery(string imei)
        {
            Imei = imei;
        }
    }
    public class GetUserByImeiResponse
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

    public class GetUserQueryHandler : IRequestHandler<GetUserByImeiQuery, GetUserByImeiResponse>
    {
        private readonly IUserRepository _userRepository;

        public GetUserQueryHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<GetUserByImeiResponse> Handle(GetUserByImeiQuery request, CancellationToken cancellationToken)
        {
            var entity = await _userRepository.BGetByImeiAsync(request.Imei);
            var result = UserMapper.Mapper.Map<GetUserByImeiResponse>(entity);
            return result;

        }
    }
}
