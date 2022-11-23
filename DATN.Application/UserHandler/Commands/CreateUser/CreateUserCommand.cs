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

namespace DATN.Application.UserHandler.Commands.CreateUser
{
	public class CreateUserCommand : IRequest<BResult>
	{
		public string MacAddress { get; set; }
		public string Name { get; set; }
		public int Age { get; set; }
		public string Address { get; set; }
		public string Phone { get; set; }
		
		public bool IsDeleted { get; set; }
		public DateTime TimingCreate { get; set; }
		public DateTime TimingUpdate { get; set; }
		public DateTime TimingDelete { get; set; }
	}
	public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, BResult>
	{
		private readonly IUserRepository _UserRepository;

		public CreateUserCommandHandler(IUserRepository userRepository)
		{
			_UserRepository = userRepository;
		}

		public async Task<BResult> Handle(CreateUserCommand request, CancellationToken cancellationToken)
		{
			var entity = UserMapper.Mapper.Map<User>(request);
			await _UserRepository.BAddAsync(entity);
			return BResult.Success();
		}
	}
}
