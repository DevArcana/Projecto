using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Flurl;
using Flurl.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using Projecto.Authentication.Interfaces;

namespace Projecto.Authentication.Services
{
    public class UserAuthModel
    {
        public string Provider { get; set; } = null!;
        public string Identifier { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string Email { get; set; } = null!;
    }
    
    public class AuthService : IAuthService
    {
        private readonly IConfiguration _configuration;
        private readonly IMemoryCache _memoryCache;

        public AuthService(IConfiguration configuration, IMemoryCache memoryCache)
        {
            _configuration = configuration;
            _memoryCache = memoryCache;
        }

        public Task<UserAuthModel> GetUserAsync(HttpContext context, CancellationToken cancellationToken)
        {
            var token = context.Request.Headers.FirstOrDefault(x => x.Key == "Authorization").Value.First();

            return _memoryCache.GetOrCreateAsync(token, async entry =>
            {
                var response = await _configuration.GetSection("Auth0")["Authority"]
                    .AppendPathSegment("userinfo")
                    .WithHeader("Authorization", token)
                    .GetJsonAsync(cancellationToken);

                var sub = ((string) response.sub).Split('|');
                var name = (string) response.name;
                var email = (string) response.email;

                return new UserAuthModel()
                {
                    Provider = sub[0],
                    Identifier = sub[1],
                    Name = name,
                    Email = email
                };
            });
        }
    }
}