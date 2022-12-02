using DATN.Application.Mapper;
using DATN.Application.Models;
using DATN.Core.Entities;
using DATN.Infastructure.Repositories.UserRepository;
using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DATN.Application.UserHandler.Commands.UpdateUser
{
    public class UpdateUserCommand : IRequest<BResult>
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

    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, BResult>
    {
        private readonly IUserRepository _userRepository;

        public UpdateUserCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<BResult> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var entity = UserMapper.Mapper.Map<User>(request);
            await _userRepository.BUpdateAsync(entity);
            return BResult.Success();
        }
    }
}
