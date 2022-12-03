using DATN.Application.Models;
using DATN.Infastructure.Repositories.UserRepository;
using MediatR;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DATN.Application.UserHandler.Commands.UpdateUser
{
	public class UpdateUserPatchCommand : IRequest<BResult>
	{
		public UpdateUserPatchCommand(int id, JsonPatchDocument requestPatch)
		{
			Id = id;
			RequestPatch = requestPatch;
		}
		public int Id { get; set; }
		public JsonPatchDocument RequestPatch { get; set; }
		//public string Op { get; set; }
		//public string Path { get; set; }
		//public string Value { get; set; }
	}

	public class UpdateUserPatchCommandHandler : IRequestHandler<UpdateUserPatchCommand, BResult>
	{
		private readonly IUserRepository _userRepository;

		public UpdateUserPatchCommandHandler(IUserRepository userRepository)
		{
			_userRepository = userRepository;

		}

		public async Task<BResult> Handle(UpdateUserPatchCommand request, CancellationToken cancellationToken)
		{
			//var entity = WifiMapper.Mapper.Map<Wifi>(request);

			await _userRepository.BUpdateTPatchAsync(request.Id, request.RequestPatch);
			return BResult.Success();
		}
	}
}
