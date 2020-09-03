using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Projecto.Infrastructure.Services;

namespace Projecto.Infrastructure.Interfaces
{
    public interface IAuthService
    {
        Task<UserAuthModel> GetUser(HttpContext context);
    }
}