using System.Linq;
using System.Threading.Tasks;
using Flurl;
using Flurl.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Projecto.Infrastructure.Interfaces;

namespace Projecto.Infrastructure.Services
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

        public AuthService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<UserAuthModel> GetUser(HttpContext context)
        {
            var token = context.Request.Headers.FirstOrDefault(x => x.Key == "Authorization").Value.First();
            var response = await _configuration.GetSection("Auth0")["Authority"]
                .AppendPathSegment("userinfo")
                .WithHeader("Authorization", token).GetJsonAsync();

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
        }
    }
}