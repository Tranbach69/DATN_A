﻿
using DATN.Application.Models;
using DATN.Infastructure.Repositories.DeviceRepository;
using MediatR;
using Microsoft.IdentityModel.Tokens;
using System;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DATN.Application.AuthHandler.Commands.TokenCommand
{
    public class TokenCommandResponse
    {
        public string AccessToken { get; set; } = default!;
        public int DeviceId { get; set; } = default!;

    }
    public class TokenCommand : IRequest<TokenCommandResponse>
    {
        public string UserName { get; set; } = default!;
        public string Password { get; set; } = default!;
    }
    public class TokenCommandHandler : IRequestHandler<TokenCommand, TokenCommandResponse>
    {
        private readonly IConfiguration _config;
        private readonly IDeviceRepository _deviceRepo;

        public TokenCommandHandler(IConfiguration config, IDeviceRepository deviceRepo)
        {
            _config = config;
            _deviceRepo = deviceRepo;
        }

        public async Task<TokenCommandResponse> Handle(TokenCommand request, CancellationToken cancellationToken)
        {
            // Verificamos credenciales con Identity
            var user = await _deviceRepo.CheckAuth(request.UserName, request.Password);
            
            if (user is null)
            {
                throw new Exception();
            }

            //var roles = await _userManager.GetRolesAsync(user);

            // Generamos un token según los claims
            var claims = new List<Claim>{
                new Claim(BClaimType.Id, user.Id.ToString()),
                new Claim(BClaimType.Name, user.UserName),
            };

			//foreach (var role in roles)
			//{
			//    claims.Add(new Claim(ClaimTypes.Role, role));
			//}

			var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);
            var tokenDescriptor = new JwtSecurityToken(
                issuer: _config["Jwt:Issuer"],
                audience: _config["Jwt:Audience"],
                claims: claims,
                expires: DateTime.Now.AddDays(7),
                signingCredentials: credentials);

            var jwt = new JwtSecurityTokenHandler().WriteToken(tokenDescriptor);
            
            return new TokenCommandResponse
            {
                AccessToken = jwt,
                DeviceId = user.Id
            };
        }
    }
}
