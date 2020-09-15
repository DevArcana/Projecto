using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Projecto.Authentication.Services;

namespace Projecto.Authentication.Interfaces
{
    public interface IAuthService
    {
        Task<UserAuthModel> GetUserAsync(HttpContext context, CancellationToken cancellationToken);
    }
}