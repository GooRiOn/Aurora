﻿using System.Linq;
using System.Threading.Tasks;
using Aurora.DomainProxy.Proxies.Interfaces;
using Aurora.Infrastructure.Data;
using Aurora.Infrastructure.Data.Interfaces;
using Aurora.Infrastructure.Helpers;
using Aurora.Infrastructure.Models.ReadModels;
using Aurora.Infrastructure.Models.WriteModels;
using Aurora.Web.Auth.Interfaces;
using Aurora.Web.Services.Interfaces;
using Microsoft.AspNet.Authorization;
using Microsoft.AspNet.Mvc;
using Microsoft.Data.Entity.Design;

namespace Aurora.Web.Controllers
{
    [Route("api/Accounts")]
    public class AccountController : BaseController
    {
        private readonly IUserDomainServiceProxy _userDomainServiceProxy;
        private readonly IUserAuthDomainServiceProxy _userAuthDomainServiceProxy;
        private readonly IOAuthService _oAuthService;
        private readonly IEmailService _emailService;
        private readonly IHttpService _httpService;
        

        public AccountController(IUserAuthDomainServiceProxy userAuthDomainServiceProxy, IOAuthService oAuthService, IEmailService emailService, 
             IHttpService httpService, IUserDomainServiceProxy userDomainServiceProxy)
        {
            _userAuthDomainServiceProxy = userAuthDomainServiceProxy;
            _oAuthService = oAuthService;
            _emailService = emailService;
            _httpService = httpService;
            _userDomainServiceProxy = userDomainServiceProxy;
        }

        [HttpPost("Register"), AllowAnonymous]
        public async Task<IResult> RegisterUserAsync([FromBody] UserRegisterWriteModel userRegister)
        {
            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values.SelectMany(v => v.Errors).Select(v => v.ErrorMessage).ToArray();
                return CreateResult(ResultStateEnum.Failed, errors);
            }

            var gravatarUrl = GravatarHelper.CreateGravatarUrl(userRegister.UserName);
            userRegister.Gravatar = await _httpService.GetByteArrayAsync(gravatarUrl);

            return await _userAuthDomainServiceProxy.CreateUserAsync(userRegister);
        }

        [HttpPost("Login"), AllowAnonymous]
        public async Task<string> LoginUserAsync([FromBody] UserLoginWriteModel userLogin)
        {
            var user = await _userAuthDomainServiceProxy.GetUserLoginInfoAsync(userLogin.UserName);

            if (user == null || !user.IsActive)
            {
                throw new OperationException("User not found");
            }

            if (user.IsLocked)
            {
                throw new OperationException("User is locked");
            }

            await _userAuthDomainServiceProxy.PasswordSignInAsync(userLogin);

            var userToken = _oAuthService.GetUserAuthToken(userLogin.UserName, user.Id, user.Roles);
            
            return userToken;
        }

        [HttpGet("SelfInfo")]
        public async Task<UserSelfInfoReadModel> GetUserSelfInfo()
        {
            var userId = GetUserId();
            var result = await _userDomainServiceProxy.GetUserSelfInfoAsync(userId);

            return result;
        }

        [HttpPost("SignOut"),AllowAnonymous]
        public async Task<IResult> SignOutAsync()
        {
            await _userAuthDomainServiceProxy.SignOutAsync();
            return new Result();
        }

        [HttpPost("Password/Reset/{email}/Email/Send"), AllowAnonymous]
        public async Task<IResult> SendPasswordResetEmailAsync(string email)
        {
            var passwordResetToken = await _userAuthDomainServiceProxy.GeneratePasswordResetTokenAsync(email);
            var encodedPasswordResetToken = Base64Helper.Encode(passwordResetToken);

            await _emailService.SendResetPaswordEmailAsync(encodedPasswordResetToken, email);
            return new Result();
        }

        [HttpPost("Password/Reset"), AllowAnonymous]
        public async Task<IResult> ResetUserPasswordAsync([FromBody]UserPasswordResetWriteModel userPasswordReset)
        {
            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values.SelectMany(v => v.Errors).Select(v => v.ErrorMessage).ToArray();
                return CreateResult(ResultStateEnum.Failed, errors);
            }

            userPasswordReset.Token = Base64Helper.Decode(userPasswordReset.Token);

            return await _userAuthDomainServiceProxy.ResetUserPasswordAsync(userPasswordReset);
        }
    }
}
