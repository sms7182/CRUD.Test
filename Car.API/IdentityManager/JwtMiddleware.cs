using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace Car.API.IdentityManager
{
    public class JwtMiddleware:IMiddleware
    {
        private readonly AppSettings _appSettings;
        private readonly IUserService _userService;
        private readonly RequestDelegate _next;
        public JwtMiddleware(IOptions<AppSettings> appSettings,IUserService userService)
        {
          
            _appSettings = appSettings.Value;
           _userService = userService;
         //   _next = next;
        }

        //public async Task Invoke(HttpContext context, IUserService userService)
        //{
        //    var token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();

        //    if (token != null)
        //        AttachUserToContext(context, userService, token);

        //    await _next(context);
        //}

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
           
            var token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();

            if (token != null)
                AttachUserToContext(context, _userService, token);

            await next(context);
        }

        private void AttachUserToContext(HttpContext context, IUserService userService, string token)
        {
            try
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
                tokenHandler.ValidateToken(token, new TokenValidationParameters
                {

                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ValidateLifetime = true,
                    SaveSigninToken = true,

              
                }, out SecurityToken validatedToken);
              
              
                var jwtToken = (JwtSecurityToken)validatedToken;
                var userName = (jwtToken.Claims.First(x => x.Type == "username").Value);

                context.Items["User"] = userService.GetByUserName(userName);
            }
            catch
            {
                
            }
        }
    }
}
