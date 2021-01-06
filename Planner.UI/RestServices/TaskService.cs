using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
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
    public class TaskService
    {
        private readonly HttpClient _client;
        private readonly ILocalStorageService _localStorage;
        AuthenticationStateProvider _stateProvider;

        public TaskService(HttpClient client,
            ILocalStorageService localStorage,
            AuthenticationStateProvider stateProvider)
        {
            _client = client;
            _localStorage = localStorage;
            _stateProvider = stateProvider;
        }

        public Task<IEnumerable<CardDTO>> GetAll()
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<CardDTO>> GetTasksByObjectId(int objectId)
        {
            var token = await _localStorage.GetItemAsync<string>("Token");
            _client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
            var response = await _client.GetAsync($@"/api/Task/GetTaskList?objectId=" + objectId);
            var responseResult = await response.Content.ReadAsStringAsync();
            return responseResult.ConvertTo<IEnumerable<CardDTO>>();
        }

        public async Task<IEnumerable<StatusDTO>> GetTaskStatusList()
        {
            var token = await _localStorage.GetItemAsync<string>("Token");
            _client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
            var response = await _client.GetAsync($@"/api/Task/GetTaskStatusList");
            var responseResult = await response.Content.ReadAsStringAsync();
            return responseResult.ConvertTo<IEnumerable<StatusDTO>>();
        }

        public async Task<CardDTO> GetAsync(int id)
        {
            var token = await _localStorage.GetItemAsync<string>("Token");
            _client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
            var response = await _client.GetAsync($@"/api/Task/GetTask?id=" + id);
            var responseResult = await response.Content.ReadAsStringAsync();
            return responseResult.ConvertTo<CardDTO>();
        }

        public async Task<CreateResponse<CardDTO>> PostAsync(CreateCardDTO card)
        {
            var token = await _localStorage.GetItemAsync<string>("Token");
            _client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
            var state = await _stateProvider.GetAuthenticationStateAsync();
            card.CreatorId = state.User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier).Value;
            var body = new StringContent(card.ToJson(), Encoding.UTF8, "application/json");
            var response = await _client.PostAsync($@"/api/Task/CreateTask", body);
            var responseResult = await response.Content.ReadAsStringAsync();
            return responseResult.ConvertTo<CreateResponse<CardDTO>>();
        }

        public async Task<ResponseResultEnum> PutAsync(CardDTO card)
        {
            var token = await _localStorage.GetItemAsync<string>("Token");
            _client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
            var body = new StringContent(card.ToJson(), Encoding.UTF8, "application/json");
            var response = await _client.PutAsync($@"/api/Task/UpdateTask", body);
            var responseResult = await response.Content.ReadAsStringAsync();
            return responseResult.ConvertTo<ResponseResultEnum>();
        }

        public async Task UpdateStatusAsync(CardDTO card)
        {
            var token = await _localStorage.GetItemAsync<string>("Token");
            _client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
            var body = new StringContent(card.ToJson(), Encoding.UTF8, "application/json");
            await _client.PutAsync($@"/api/Task/UpdateStatus", body);
        }

        public async Task<ResponseResultEnum> DeleteTaskAsync(int taskId)
        {
            var token = await _localStorage.GetItemAsync<string>("Token");
            _client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
            var response = await _client.DeleteAsync($@"/api/Task/DeleteTask?taskId=" + taskId);
            var responseResult = await response.Content.ReadAsStringAsync();
            return responseResult.ConvertTo<ResponseResultEnum>();
        }

        public async Task<IEnumerable<TaskColorDTO>> GetColors()
        {
            var token = await _localStorage.GetItemAsync<string>("Token");
            _client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
            var response = await _client.GetAsync($@"/api/Task/GetColors");
            var responseResult = await response.Content.ReadAsStringAsync();
            return responseResult.ConvertTo<IEnumerable<TaskColorDTO>>();
        }
    }
}
