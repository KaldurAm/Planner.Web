using Planner.Shared.Models;
using Planner.UI.Extensions;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Planner.UI.RestServices
{
    public class AuthService
    {
        private readonly HttpClient _client;

        public AuthService(HttpClient client)
        {
            _client = client;
        }

        public async Task<UserManagerResponse> RegisterUserAsync(RegisterRequest request)
        {
            var body = new StringContent(request.ToJson(), Encoding.UTF8, "application/json");
            var response = await _client.PostAsync($@"/api/auth/register", body);
            var responseResult = await response.Content.ReadAsStringAsync();
            return responseResult.ConvertTo<UserManagerResponse>();
        }

        public async Task<UserManagerResponse> LoginUserAsync(LoginRequest request)
        {
            var body = new StringContent(request.ToJson(), Encoding.UTF8, "application/json");
            var response = await _client.PostAsync($@"/api/auth/login", body);
            var responseResult = await response.Content.ReadAsStringAsync();
            return responseResult.ConvertTo<UserManagerResponse>();
        }
    }
}
