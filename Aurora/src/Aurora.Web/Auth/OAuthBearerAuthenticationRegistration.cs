using System;
using System.IdentityModel.Tokens;
using System.Security.Cryptography;
using Aurora.DataAccess.Identity;
using Microsoft.AspNet.Authentication.JwtBearer;
using Microsoft.AspNet.Authorization;
using Microsoft.AspNet.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace Aurora.Web.Auth
{
    public static class OAuthBearerAuthenticationRegistration
    {
        private const string _audience = "Aurora";
        private const string _issuer = "self";
   
        public static void RegisterBearerPolicy(this IServiceCollection services)
        {
            services.AddAuthorization(auth =>
            {
                auth.AddPolicy("User", new AuthorizationPolicyBuilder()
                    .AddRequirements()
                    .AddAuthenticationSchemes(JwtBearerDefaults.AuthenticationScheme)
                    .RequireAuthenticatedUser().Build());

                auth.AddPolicy("Admin", new AuthorizationPolicyBuilder()
                    .AddAuthenticationSchemes(JwtBearerDefaults.AuthenticationScheme)
                    .AddRequirements(new OnlyRoleRequirement(RoleNames.Admin))
                    .RequireAuthenticatedUser().Build());
            });
        }

        public static void RegisterTokenAuthorizationOptions(this IServiceCollection services)
        {
            var key = new RsaSecurityKey(GetNewRSAKey());

            var tokenOptions = new TokenAuthOptions
            {
                Audience = _audience,
                Issuer = _issuer,
                SigningCredentials = new SigningCredentials(key, SecurityAlgorithms.RsaSha256Signature)
            };

            services.AddInstance(tokenOptions);
        }

        public static void RegisterBearerAuthentication(this IApplicationBuilder app, TokenAuthOptions tokenAuthOptions)
        {
            app.Use(next => async context =>
            {
                try
                {
                    await next(context);
                }
                catch (Exception e)
                {
                    if (context.Response.HasStarted) throw e;
                    context.Response.StatusCode = 401;
                }
            });


            app.UseJwtBearerAuthentication(options =>
            {
                options.TokenValidationParameters.IssuerSigningKey = tokenAuthOptions.SigningCredentials.Key;
                options.TokenValidationParameters.ValidAudience = tokenAuthOptions.Audience;
                options.TokenValidationParameters.ValidIssuer = tokenAuthOptions.Issuer;
                options.TokenValidationParameters.ValidateSignature = true;
                options.TokenValidationParameters.ValidateLifetime = true;
                options.TokenValidationParameters.ClockSkew = TimeSpan.Zero;
            });
        }

        private static RSAParameters GetNewRSAKey()
        {
            using (var rsa = new RSACryptoServiceProvider(2048))
            {
                try
                {
                    return rsa.ExportParameters(true);
                }
                finally
                {
                    rsa.PersistKeyInCsp = false;
                }
            }
        }
    }
}
