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
    public class CurrencyService : IRestService<CurrencyDTO>
    {
        private readonly HttpClient _client;

        public CurrencyService(HttpClient client)
        {
            _client = client;
        }

        public async Task<IEnumerable<CurrencyDTO>> GetAll()
        {
            var response = await _client.GetAsync($@"/api/currency/getall");
            var responseResult = await response.Content.ReadAsStringAsync();
            var result = responseResult.ConvertTo<IEnumerable<CurrencyDTO>>();
            return result;
        }

        public Task<CurrencyDTO> GetAsync()
        {
            throw new NotImplementedException();
        }

        public Task<CurrencyDTO> PostAsync(CurrencyDTO currency)
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
