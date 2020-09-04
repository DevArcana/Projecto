using System.Threading;
using System.Threading.Tasks;
using Projecto.Domain.Entities;
using Projecto.Domain.Interfaces;

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

        public async Task SetUserFromEmail(string email, CancellationToken cancellationToken)
        {
            User = await _userService.GetUserByEmailAsync(email, cancellationToken);
        }
    }
}