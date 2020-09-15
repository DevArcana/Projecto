using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Caching.Memory;
using Projecto.Authentication;
using Projecto.Authentication.Interfaces;

namespace Projecto.Infrastructure.Behaviours
{
    public class AuthenticationBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IAuthService _authService;
        private readonly UserContext _userContext;

        public AuthenticationBehaviour(IHttpContextAccessor httpContextAccessor, UserContext userContext, IAuthService authService)
        {
            _httpContextAccessor = httpContextAccessor;
            _userContext = userContext;
            _authService = authService;
        }

        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            var user = await _authService.GetUserAsync(_httpContextAccessor.HttpContext, cancellationToken);
            await _userContext.SetUserFromAuthModel(user, cancellationToken);
            return await next();
        }
    }
}