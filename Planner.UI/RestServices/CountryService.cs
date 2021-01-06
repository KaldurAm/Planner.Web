using Planner.Shared.Enums;
using Planner.Shared.Models;
using Planner.UI.Interfaces;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Planner.UI.RestServices
{
    public class CountryService : IRestService<CountryDTO>
    {
        private readonly HttpClient _client;

        public CountryService(HttpClient client)
        {
            _client = client;
        }

        public Task<IEnumerable<CountryDTO>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<CountryDTO> GetAsync()
        {
            throw new NotImplementedException();
        }

        public Task<CountryDTO> PostAsync(CountryDTO country)
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
