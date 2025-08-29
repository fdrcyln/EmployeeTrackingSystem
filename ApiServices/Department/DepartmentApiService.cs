using System.Net.Http.Json;

namespace ApiServices.Department
{
    public class DepartmentApiService
    {
        private readonly HttpClient _http;
        private readonly string _root = "https://localhost:7128/api/Departments";

        public DepartmentApiService()
        {
            var handler = new HttpClientHandler();
            handler.ServerCertificateCustomValidationCallback = (m, c, ch, e) => true; 
            _http = new HttpClient(handler) { Timeout = TimeSpan.FromSeconds(15) };
        }

        public async Task<ApiResponse<List<DepartmentDto>>?> GetAllAsync()
        {
            var resp = await _http.GetAsync(_root + "/GetAll");
            return await resp.Content.ReadFromJsonAsync<ApiResponse<List<DepartmentDto>>>();
        }

        public async Task<ApiResponse<DepartmentDto>?> AddAsync(DepartmentDto dto)
        {
            var resp = await _http.PostAsJsonAsync(_root + "/Add", dto);
            return await resp.Content.ReadFromJsonAsync<ApiResponse<DepartmentDto>>();
        }

        public async Task<ApiResponse<DepartmentDto>?> UpdateAsync(DepartmentDto dto)
        {
            var resp = await _http.PostAsJsonAsync(_root + "/Update", dto);
            return await resp.Content.ReadFromJsonAsync<ApiResponse<DepartmentDto>>();
        }

        public async Task<ApiResponse<object>?> DeleteAsync(int id)
        {
            var resp = await _http.DeleteAsync($"{_root}/Delete/{id}");
            return await resp.Content.ReadFromJsonAsync<ApiResponse<object>>();
        }
    }

    public class DepartmentDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int BranchId { get; set; }
    }

    public class ApiResponse<T>
    {
        public bool Success { get; set; }
        public string Message { get; set; } = string.Empty;
        public T? Data { get; set; }
    }
}
