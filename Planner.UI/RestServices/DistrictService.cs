using Blazored.LocalStorage;
using Planner.Shared.Enums;
using Planner.Shared.Models;
using Planner.UI.Extensions;
using Planner.UI.Interfaces;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Planner.UI.RestServices
{
    public class DistrictService : IRestService<DistrictDTO>
    {
        private readonly HttpClient _client;
        private readonly ILocalStorageService _localStorage;

        public DistrictService(HttpClient client,
            ILocalStorageService localStorage)
        {
            _client = client;
            _localStorage = localStorage;
        }

        public async Task<IEnumerable<DistrictDTO>> GetAll()
        {
            var token = await _localStorage.GetItemAsync<string>("Token");
            _client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
            var response = await _client.GetAsync($@"/api/district/getall");
            var responseResult = await response.Content.ReadAsStringAsync();
            var result = responseResult.ConvertTo<IEnumerable<DistrictDTO>>();
            return result;
        }

        public async Task<IEnumerable<DistrictWithObjectsTree>> GetDistrictTree()
        {
            var token = await _localStorage.GetItemAsync<string>("Token");
            _client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
            var response = await _client.GetAsync($@"/api/District/GetTree");
            var responseResult = await response.Content.ReadAsStringAsync();
            var result = responseResult.ConvertTo<IEnumerable<DistrictWithObjectsTree>>();
            return result;
        }

        public async Task<DistrictDTO> GetAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<DistrictDTO> PostAsync(DistrictDTO district)
        {
            throw new NotImplementedException();
        }

        public async Task<ResponseResultEnum> PutAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<ResponseResultEnum> DeleteAsync()
        {
            throw new NotImplementedException();
        }
    }
}
