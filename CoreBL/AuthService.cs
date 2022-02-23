using CoreBL.Models;
using CoreDAL.Entities;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace CoreBL
{
    public class AuthService : IAuthService
    {
        private readonly AuthOptions _authOptions;
        private readonly SigningCredentials _signingCredentials;

        public AuthService(IOptions<AuthOptions> authOptions)
        {
            _authOptions = authOptions.Value;
            _signingCredentials = new SigningCredentials(new SymmetricSecurityKey
                            (Encoding.ASCII.GetBytes(_authOptions.SecretKey)),
                            SecurityAlgorithms.HmacSha256);
        }

        public string CreateAuthToken(string login)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, login),
                new Claim(ClaimsIdentity.DefaultRoleClaimType, "Admin")
            };

            var token = new JwtSecurityToken(
                    issuer: _authOptions.Issuer,
                    audience: _authOptions.Audience,
                    notBefore: DateTime.UtcNow,
                    claims: claims,
                    expires: DateTime.UtcNow.Add(TimeSpan.FromMinutes(_authOptions.TokenLifetime)),
                    signingCredentials: _signingCredentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        //public UserInfo GetUserInfoFromToken(string headerToken)
        //{
        //    var token = headerToken.Substring(headerToken.IndexOf(' ') + 1);

        //    var handler = new JwtSecurityTokenHandler();
        //    var jsonToken = handler.ReadToken(token);
        //    var tokenS = jsonToken as JwtSecurityToken;

        //    return new UserInfo
        //    {
        //        Login = tokenS.Claims.First(x => x.Type == ClaimsIdentity.DefaultNameClaimType).Value,
        //        Role = (Role)Enum.Parse(typeof(Role), tokenS.Claims.First(x => x.Type == ClaimsIdentity.DefaultRoleClaimType).Value)
        //    };
        //}
    }
}
