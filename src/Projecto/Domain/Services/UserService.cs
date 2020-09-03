using System.Threading.Tasks;
using Projecto.Domain.Entities;
using Projecto.Domain.Interfaces;

namespace Projecto.Domain.Services
{
    public class UserService : IUserService
    {
        public Task<User> GetUserByEmailAsync(string email)
        {
            throw new System.NotImplementedException();
        }

        public Task<User> CreateUserAsync(string email, string displayName)
        {
            throw new System.NotImplementedException();
        }
    }
}