using System.Threading;
using System.Threading.Tasks;
using Projecto.Domain.Entities;

namespace Projecto.Domain.Interfaces
{
    public interface IUserService
    {
        Task<User?> GetUserByEmailAsync(string email, CancellationToken cancellationToken);
        Task<User?> CreateUserAsync(string email, string displayName, CancellationToken cancellationToken);
    }
}