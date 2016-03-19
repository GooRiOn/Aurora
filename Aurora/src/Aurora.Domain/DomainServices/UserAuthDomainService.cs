using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading.Tasks;
using Aurora.Domain.DomainServices.Interfaces;
using Aurora.DataAccess.Entities;
using Aurora.Domain.DomainObjects;
using Aurora.Domain.Mappings;
using Aurora.Infrastructure.Auth;
using Microsoft.AspNet.Identity;

namespace Aurora.Domain.DomainServices
{
    public sealed class UserAuthDomainService : IUserAuthDomainService
    {
        private readonly UserManager<UserEntity> _userManager;
        private readonly SignInManager<UserEntity> _signInManager;
        private readonly TokenAuthOptions _tokenAuthOptions;

        public UserAuthDomainService(UserManager<UserEntity> userManager, SignInManager<UserEntity> signInManager, TokenAuthOptions tokenAuthOptions)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _tokenAuthOptions = tokenAuthOptions;
        }

        public async Task<IdentityResult> CreateUserAsync(UserCreateDomainObject userCreateDomainObject)
        {
            var userEntity = userCreateDomainObject.AsEntity();
            return await _userManager.CreateAsync(userEntity, userCreateDomainObject.Password);
        }

        public async Task<SignInResult> PasswordSignInAsync(UserLoginDomainObject userLoginModel)
        {
            return await _signInManager.PasswordSignInAsync(userLoginModel.UserName,userLoginModel.Password, userLoginModel.RememberMe, lockoutOnFailure: false);
        }

        public async Task SignOutAsync()
        {
            await _signInManager.SignOutAsync();
        }

        public async Task<string> GetUserAuthToken(string userName)
        {
            var handler = new JwtSecurityTokenHandler();
            var user = await _userManager.FindByNameAsync(userName);

            var identity = new ClaimsIdentity(new GenericIdentity(user.Email, "TokenAuth"), new[] { new Claim("UserId", user.Id, ClaimValueTypes.Integer) });

            var securityToken = handler.CreateToken(
                _tokenAuthOptions.Issuer, 
                _tokenAuthOptions.Audience,
                signingCredentials: _tokenAuthOptions.SigningCredentials,
                subject: identity,
                expires: null
                );

            return handler.WriteToken(securityToken);
        }
    }
}
