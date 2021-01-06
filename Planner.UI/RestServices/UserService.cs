using Blazored.LocalStorage;
using Planner.Shared.Enums;
using Planner.Shared.Models;
using Planner.UI.Extensions;
using Planner.UI.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Planner.UI.RestServices
{
    public class UserService : IRestService<ApplicationUserDTO>
    {
        private readonly HttpClient _client;
        private readonly ILocalStorageService _localStorage;

        public UserService(HttpClient client,
            ILocalStorageService localStorage)
        {
            _client = client;
            _localStorage = localStorage;
        }

        public async Task<IEnumerable<ApplicationUserDTO>> GetUsers()
        {
            var token = await _localStorage.GetItemAsync<string>("Token");
            _client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
            var response = await _client.GetAsync($@"/api/User/GetUsers");
            var responseResult = await response.Content.ReadAsStringAsync();
            return responseResult.ConvertTo<IEnumerable<ApplicationUserDTO>>();
        }

        public async Task<IEnumerable<UserDTO>> GetUsersInfo()
        {
            var token = await _localStorage.GetItemAsync<string>("Token");
            _client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
            var response = await _client.GetAsync($@"/api/User/GetUsersInfo");
            var responseResult = await response.Content.ReadAsStringAsync();
            return responseResult.ConvertTo<IEnumerable<UserDTO>>();
        }

        public async Task<ApplicationUserDTO> GetUser(string id)
        {
            var token = await _localStorage.GetItemAsync<string>("Token");
            _client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
            var response = await _client.GetAsync($@"/api/User/GetUser?userId=" + id);
            var responseResult = await response.Content.ReadAsStringAsync();
            return responseResult.ConvertTo<ApplicationUserDTO>();
        }

        public async Task<IEnumerable<RoleDTO>> GetRoles()
        {
            var token = await _localStorage.GetItemAsync<string>("Token");
            _client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
            var response = await _client.GetAsync($@"/api/User/GetRoles");
            var responseResult = await response.Content.ReadAsStringAsync();
            return responseResult.ConvertTo<IEnumerable<RoleDTO>>();
        }

        public async Task<ResponseResultEnum> UpdateRoles(ApplicationUserDTO user)
        {
            var token = await _localStorage.GetItemAsync<string>("Token");
            _client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
            var body = new StringContent(user.ToJson(), Encoding.UTF8, "application/json");
            var response = await _client.PostAsync($@"/api/User/UpdateRoles", body);
            var responseResult = await response.Content.ReadAsStringAsync();
            return responseResult.ConvertTo<ResponseResultEnum>();
        }

        public Task<IEnumerable<ApplicationUserDTO>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<ApplicationUserDTO> GetAsync()
        {
            throw new NotImplementedException();
        }

        public Task<ApplicationUserDTO> PostAsync(ApplicationUserDTO user)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseResultEnum> PutAsync()
        {
            throw new NotImplementedException();
        }

        public Task<ResponseResultEnum> DeleteAsync()
        {
            throw new NotImplementedException();
        }
    }
}
