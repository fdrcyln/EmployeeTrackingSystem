using System;
using System.Collections.Generic;
using System.Net.Http.Json;
using System.Net.Http;
using System.Threading.Tasks;

namespace ApiServices.Branch
{
    public class BranchApiServices
    {
        private readonly HttpClient _http;
        private readonly string _root = "https://localhost:7128/api/Branches"; 

        public BranchApiServices(HttpClient http)
        {
            _http = http;
        }

        public BranchApiServices() : this(CreateDefaultClient()) { }

        private static HttpClient CreateDefaultClient()
        {
            var handler = new HttpClientHandler();
            handler.ServerCertificateCustomValidationCallback = (m, c, ch, e) => true; // dev only
            return new HttpClient(handler) { Timeout = TimeSpan.FromSeconds(15) };
        }

        public async Task<ApiResponse<List<BranchDto>>?> GetAllAsync()
        {
            var resp = await _http.GetAsync(_root + "/GetAll");
            return await resp.Content.ReadFromJsonAsync<ApiResponse<List<BranchDto>>>();
        }

        public async Task<ApiResponse<BranchDto>?> GetByIdAsync(int id)
        {
            var resp = await _http.GetAsync($"{_root}/GetById/{id}");
            return await resp.Content.ReadFromJsonAsync<ApiResponse<BranchDto>>();
        }

        public async Task<ApiResponse<BranchDto>?> AddAsync(BranchDto dto)
        {
            var resp = await _http.PostAsJsonAsync(_root + "/Add", dto);
            return await resp.Content.ReadFromJsonAsync<ApiResponse<BranchDto>>();
        }

        public async Task<ApiResponse<BranchDto>?> UpdateAsync(BranchDto dto)
        {
            var resp = await _http.PostAsJsonAsync(_root + "/Update", dto);
            return await resp.Content.ReadFromJsonAsync<ApiResponse<BranchDto>>();
        }

        public async Task<ApiResponse<object>?> DeleteAsync(int id)
        {
            var resp = await _http.DeleteAsync($"{_root}/Delete/{id}");
            return await resp.Content.ReadFromJsonAsync<ApiResponse<object>>();
        }
    }

    public class BranchDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
    }
    public class ApiResponse<T>
    {
        public bool Success { get; set; }
        public string Message { get; set; } = string.Empty;
        public T? Data { get; set; }
    }
}
