
using DATN.Application.Models;

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
using DATN.Infastructure.Repositories.AccountAdminRepository;

namespace DATN.Application.AuthHandler.Commands.TokenCommandAdmin
{
    public class TokenCommandAdminResponse
    {
        public string AccessToken { get; set; } = default!;
    }
    public class TokenCommandAdmin : IRequest<TokenCommandAdminResponse>
    {
        public string UserName { get; set; } = default!;
        public string Password { get; set; } = default!;
    }
    public class TokenCommandAdminHandler : IRequestHandler<TokenCommandAdmin, TokenCommandAdminResponse>
    {
        private readonly IConfiguration _config;
        private readonly IAccountAdminRepository _AccAdminRepo;

        public TokenCommandAdminHandler(IConfiguration config, IAccountAdminRepository accAdminRepo)
        {
            _config = config;
            _AccAdminRepo = accAdminRepo;
        }

        public async Task<TokenCommandAdminResponse> Handle(TokenCommandAdmin request, CancellationToken cancellationToken)
        {   
            // Verificamos credenciales con Identity
            var user = await _AccAdminRepo.CheckAuth(request.UserName, request.Password);

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

            return new TokenCommandAdminResponse
            {
                AccessToken = jwt
            };
        }
    }
}
