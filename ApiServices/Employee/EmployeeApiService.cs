using System.Net.Http.Json;
using Entities.Concrete;

namespace ApiServices.Employee
{
  
    public class EmployeeApiService
    {
        private readonly HttpClient _httpClient;
        private readonly string _baseUrl = "https://localhost:7128/api/Employees"; 

        public EmployeeApiService()
        {
            // Sertifika falan diyo ?
            var handler = new HttpClientHandler();
            handler.ServerCertificateCustomValidationCallback = (msg, cert, chain, errors) => true;
            _httpClient = new HttpClient(handler);
            _httpClient.Timeout = TimeSpan.FromSeconds(15);
        }

        
        public async Task<List<EmployeeDto>> GetAllAsync()
        {
            try
            {
                var resp = await _httpClient.GetAsync(_baseUrl + "/GetAll");
                var api = await resp.Content.ReadFromJsonAsync<ApiResponse<List<EmployeeDto>>>();
                if (api != null && api.Success && api.Data != null)
                {
                    return api.Data;
                }
                return new List<EmployeeDto>();
            }
            catch
            {
                return new List<EmployeeDto>();
            }
        }

        
        public async Task<ApiResponse<Entities.Concrete.Employee>> AddAsync(EmployeeDto dto)
        {
                var resp = await _httpClient.PostAsJsonAsync(_baseUrl + "/Add", dto);
                var api = await resp.Content.ReadFromJsonAsync<ApiResponse<Entities.Concrete.Employee>>();
                return api;
        }

   
        public async Task<ApiResponse<Entities.Concrete.Employee>> UpdateAsync(EmployeeDto dto)
        {
                var resp = await _httpClient.PostAsJsonAsync(_baseUrl + "/Update", dto);
                var api = await resp.Content.ReadFromJsonAsync<ApiResponse<Entities.Concrete.Employee>>();
                return api;

        }

   
        public async Task<(bool ok, string message)> DeleteAsync(int id)
        {
            try
            {
                var resp = await _httpClient.DeleteAsync(_baseUrl + "/Delete/" + id);
                var api = await resp.Content.ReadFromJsonAsync<ApiResponse<object>>();
                if (api != null)
                {
                    return (api.Success, api.Message);
                }
                return (false, "Bilinmeyen cevap");
            }
            catch (Exception ex)
            {
                return (false, ex.Message);
            }
        }

        public async Task<ApiResponse<Entities.Concrete.Employee>?> GetByIdAsync(int id)
        {
            try
            {
                var resp = await _httpClient.GetAsync(_baseUrl + "/GetById/" + id);
                return await resp.Content.ReadFromJsonAsync<ApiResponse<Entities.Concrete.Employee>>();
            }
            catch
            {
                return null;
            }
        }
    }

   
    public class ApiResponse<T>
    {
        public bool Success { get; set; }
        public string Message { get; set; } = string.Empty;
        public T? Data { get; set; }
    }

    
    public class EmployeeDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string NationalId { get; set; } = string.Empty;
        public string Gender { get; set; } = string.Empty;
        public int? Salary { get; set; }
        public DateTime? BirthDate { get; set; }
    }
}
