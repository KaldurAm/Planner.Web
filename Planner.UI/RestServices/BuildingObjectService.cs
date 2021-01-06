using Blazored.LocalStorage;
using Planner.Shared.Enums;
using Planner.Shared.Models;
using Planner.UI.Extensions;
using Planner.UI.Interfaces;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Planner.UI.RestServices
{
    public class BuildingObjectService
    {
        private readonly HttpClient _client;
        private readonly ILocalStorageService _localStorage;

        public BuildingObjectService(HttpClient client,
            ILocalStorageService localStorage)
        {
            _client = client;
            _localStorage = localStorage;
        }

        public async Task<IEnumerable<DisplayObjectDTO>> GetAll()
        {
            var token = await _localStorage.GetItemAsync<string>("Token");
            _client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
            var response = await _client.GetAsync($@"/api/object/getobjectsfordisplay");
            var responseResult = await response.Content.ReadAsStringAsync();
            return responseResult.ConvertTo<IEnumerable<DisplayObjectDTO>>();
        }

        public async Task<IEnumerable<ActualBuildingObjectTree>> GetActualObjectsTree()
        {
            var token = await _localStorage.GetItemAsync<string>("Token");
            _client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
            var response = await _client.GetAsync($@"/api/object/getobjectstree");
            var responseResult = await response.Content.ReadAsStringAsync();
            return responseResult.ConvertTo<IEnumerable<ActualBuildingObjectTree>>();
        }

        public async Task<IEnumerable<ObjectSelection>> GetObjectsForSelect()
        {
            var token = await _localStorage.GetItemAsync<string>("Token");
            _client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
            var response = await _client.GetAsync($@"/api/object/GetObjectsForSelect");
            var responseResult = await response.Content.ReadAsStringAsync();
            return responseResult.ConvertTo<IEnumerable<ObjectSelection>>();
        }

        public async Task<ObjectDetailDTO> GetById(int objectId)
        {
            var token = await _localStorage.GetItemAsync<string>("Token");
            _client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
            var response = await _client.GetAsync($@"/api/object/GetById?id=" + objectId);
            var responseResult = await response.Content.ReadAsStringAsync();
            return responseResult.ConvertTo<ObjectDetailDTO>();
        }

        public async Task<ObjectDTO> GetForEdit(int id)
        {
            var token = await _localStorage.GetItemAsync<string>("Token");
            _client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
            var response = await _client.GetAsync($@"/api/object/GetForEdit?id=" + id);
            var responseResult = await response.Content.ReadAsStringAsync();
            return responseResult.ConvertTo<ObjectDTO>();
        }

        public Task<ObjectDTO> GetAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<ObjectStatusDTO>> GetStatuses()
        {
            var token = await _localStorage.GetItemAsync<string>("Token");
            _client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
            var response = await _client.GetAsync($@"/api/object/getstatuslist");
            var responseResult = await response.Content.ReadAsStringAsync();
            return responseResult.ConvertTo<IEnumerable<ObjectStatusDTO>>();
        }

        public async Task<CreateResponse<ObjectDTO>> PostAsync(ObjectDTO request)
        {
            var token = await _localStorage.GetItemAsync<string>("Token");
            _client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
            request.CreateDate = DateTime.Now;
            var body = new StringContent(request.ToJson(), Encoding.UTF8, "application/json");
            var response = await _client.PostAsync($@"/api/object/createobject", body);
            var responseResult = await response.Content.ReadAsStringAsync();
            return responseResult.ConvertTo<CreateResponse<ObjectDTO>>();
        }

        public async Task<ResponseResultEnum> PutAsync(ObjectDTO request)
        {
            var token = await _localStorage.GetItemAsync<string>("Token");
            _client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
            request.CreateDate = DateTime.Now;
            var body = new StringContent(request.ToJson(), Encoding.UTF8, "application/json");
            var response = await _client.PutAsync($@"/api/object/UpdateObject", body);
            var responseResult = await response.Content.ReadAsStringAsync();
            return responseResult.ConvertTo<ResponseResultEnum>();
        }

        public async Task<ResponseResultEnum> DeleteAsync(int id)
        {
            var token = await _localStorage.GetItemAsync<string>("Token");
            _client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
            var response = await _client.DeleteAsync($@"/api/object/DeleteObject?id=" + id);
            var responseResult = await response.Content.ReadAsStringAsync();
            return responseResult.ConvertTo<ResponseResultEnum>();
        }

        public Task<ObjectDTO> PostAsync()
        {
            throw new NotImplementedException();
        }
    }
}
