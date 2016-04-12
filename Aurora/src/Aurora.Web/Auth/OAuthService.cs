using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Principal;
using Aurora.Web.Auth.Interfaces;

namespace Aurora.Web.Auth
{
    public sealed class OAuthService : IOAuthService
    {
        private readonly TokenAuthOptions _tokenAuthOptions;

        public OAuthService(TokenAuthOptions tokenAuthOptions)
        {
            _tokenAuthOptions = tokenAuthOptions;
        }

        public string GetUserAuthToken(string userName, string userId, string[] roles)
        {
            var handler = new JwtSecurityTokenHandler();

            var identity = new ClaimsIdentity(new GenericIdentity(userName, "TokenAuth"), new[]
            {
                new Claim("UserId", userId, ClaimValueTypes.String)
            });

            foreach (var role in roles)
                identity.AddClaim(new Claim("role",role));

            var securityToken = handler.CreateToken(
                _tokenAuthOptions.Issuer,
                _tokenAuthOptions.Audience,
                signingCredentials: _tokenAuthOptions.SigningCredentials,
                subject: identity,
                expires: DateTime.UtcNow.AddDays(14));

            return handler.WriteToken(securityToken);
        }
    }
}
