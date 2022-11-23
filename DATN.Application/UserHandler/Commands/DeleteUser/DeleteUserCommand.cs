using DATN.Application.Models;
using DATN.Infastructure.Repositories.UserRepository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DATN.Application.UserHandler.Commands.DeleteUser
{
    public class DeleteUserCommand : IRequest<BResult>
    {
        public int Id { get; set; }

        public DeleteUserCommand(int id)
        {
            Id = id;
        }
    }

    public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand, BResult>
    {
        private readonly IUserRepository _UserRepository;

        public DeleteUserCommandHandler(IUserRepository userRepository)
        {
            _UserRepository = userRepository;
        }

        public async Task<BResult> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            await _UserRepository.BDeleteByIdAsync(request.Id);
            return BResult.Success();
        }
    }
}
