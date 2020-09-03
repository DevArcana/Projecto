using System.Globalization;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Projecto.Domain.Interfaces;
using Projecto.Infrastructure.Interfaces;

namespace Projecto.Infrastructure.Auth
{
    public class EnsureUserCreatedMiddleware
    {
        private readonly RequestDelegate _next;

        public EnsureUserCreatedMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context, IAuthService authService, IUserService userService)
        {
            if (!context.User.Identity.IsAuthenticated)
            {
                await _next(context);
                return;
            }
            
            var user = await authService.GetUserAsync(context, CancellationToken.None);
            await userService.CreateUserAsync(user.Email, user.Name, CancellationToken.None);
            await _next(context);
        }
    }
}