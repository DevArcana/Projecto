using System.Threading;
using System.Threading.Tasks;
using Projecto.Domain.Entities;
using Projecto.Domain.Interfaces;
using Projecto.Infrastructure.Services;

namespace Projecto.Infrastructure.Auth
{
    public class UserContext
    {
        private readonly IUserService _userService;

        public User? User { get; private set; }
        
        public UserContext(IUserService userService)
        {
            _userService = userService;
        }

        public async Task SetUserFromAuthModel(UserAuthModel user, CancellationToken cancellationToken)
        {
            User = await _userService.CreateUserAsync(user.Email, user.Name, cancellationToken);
            User ??= await _userService.GetUserByEmailAsync(user.Email, cancellationToken);
        }
    }
}