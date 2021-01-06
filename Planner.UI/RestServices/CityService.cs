using Planner.Shared.Enums;
using Planner.Shared.Models;
using Planner.UI.Interfaces;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Planner.UI.RestServices
{
    public class CityService : IRestService<CityDTO>
    {
        private readonly HttpClient _client;

        public CityService(HttpClient client)
        {
            _client = client;
        }

        public Task<IEnumerable<CityDTO>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<CityDTO> GetAsync()
        {
            throw new NotImplementedException();
        }

        public Task<CityDTO> PostAsync(CityDTO city)
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
