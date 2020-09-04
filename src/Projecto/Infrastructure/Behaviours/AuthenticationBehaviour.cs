using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http;
using Projecto.Infrastructure.Auth;
using Projecto.Infrastructure.Interfaces;

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