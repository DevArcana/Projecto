using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Projecto.Domain.Entities;
using Projecto.Domain.Interfaces;
using Projecto.Infrastructure.Persistance;

namespace Projecto.Domain.Services
{
    public class UserService : IUserService
    {
        private readonly AppDbContext _context;

        public UserService(AppDbContext context)
        {
            _context = context;
        }

        public Task<User?> GetUserByEmailAsync(string email, CancellationToken cancellationToken)
        {
            return _context.Users.FirstOrDefaultAsync(x => x.PrimaryEmail == email, cancellationToken)!;
        }

        public async Task<User?> CreateUserAsync(string email, string displayName, CancellationToken cancellationToken)
        {
            try
            {
                var user = new User()
                {
                    PrimaryEmail = email,
                    DisplayName = displayName
                };

                _context.Add(user);

                await _context.SaveChangesAsync(cancellationToken);

                return user;
            }
            catch (DbUpdateException exception)
            {
                
            }
            
            return null;
        }
    }
}