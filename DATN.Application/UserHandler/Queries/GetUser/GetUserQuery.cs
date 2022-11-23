using DATN.Application.Mapper;
using DATN.Core.Entities;
using DATN.Infastructure.Repositories.UserRepository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DATN.Application.UserHandler.Queries.GetUser
{
    public class GetUserQuery : IRequest<GetUserResponse>
    {
        public int Id { get; set; }

        public GetUserQuery(int id)
        {
            Id = id;
        }
    }
    public class GetUserResponse
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

    public class GetUserQueryHandler : IRequestHandler<GetUserQuery, GetUserResponse>
    {
        private readonly IUserRepository _UserRepository;

        public GetUserQueryHandler(IUserRepository UserRepository)
        {
            _UserRepository = UserRepository;
        }

        public async Task<GetUserResponse> Handle(GetUserQuery request, CancellationToken cancellationToken)
        {
            var entity = await _UserRepository.BGetByIdAsync(request.Id);
            var result = UserMapper.Mapper.Map<GetUserResponse>(entity);
            return result;

        }
    }
}
