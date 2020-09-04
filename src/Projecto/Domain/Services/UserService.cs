using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Projecto.Domain.Entities;
using Projecto.Domain.Interfaces;
using Projecto.Infrastructure.Persistance;

namespace Projecto.Domain.Services
{
    public class UserService : IUserService
    {
        private readonly AppDbContext _context;
        private readonly IMemoryCache _memoryCache;

        public UserService(AppDbContext context, IMemoryCache memoryCache)
        {
            _context = context;
            _memoryCache = memoryCache;
        }

        public Task<User?> GetUserByEmailAsync(string email, CancellationToken cancellationToken)
        {
            return _memoryCache.GetOrCreateAsync(email, entry =>
            {
                return _context.Users.FirstOrDefaultAsync(x => x.PrimaryEmail == email, cancellationToken)!;
            })!;
        }

        public async Task<User?> CreateUserAsync(string email, string displayName, CancellationToken cancellationToken)
        {
            if (_memoryCache.TryGetValue(email, out var cachedUser))
            {
                if (cachedUser != null) return null;
            }
            
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