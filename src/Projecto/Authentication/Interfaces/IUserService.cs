using System.Threading;
using System.Threading.Tasks;

namespace Projecto.Authentication.Interfaces
{
    public interface IUserService
    {
        Task<User?> GetUserByEmailAsync(string email, CancellationToken cancellationToken);
        Task<User?> CreateUserAsync(string email, string displayName, CancellationToken cancellationToken);
    }
}