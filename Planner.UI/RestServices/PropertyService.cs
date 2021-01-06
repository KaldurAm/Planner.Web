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
    public class PropertyService : IRestService<AreaPropertyDTO>
    {
        private readonly HttpClient _client;

        public PropertyService(HttpClient client)
        {
            _client = client;
        }

        public async Task<IEnumerable<AreaPropertyDTO>> GetAll()
        {
            var response = await _client.GetAsync($@"/api/property/getall");
            var responseResult = await response.Content.ReadAsStringAsync();
            var result = responseResult.ConvertTo<IEnumerable<AreaPropertyDTO>>();
            return result;
        }

        public Task<AreaPropertyDTO> GetAsync()
        {
            throw new NotImplementedException();
        }

        public Task<AreaPropertyDTO> PostAsync(AreaPropertyDTO property)
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
