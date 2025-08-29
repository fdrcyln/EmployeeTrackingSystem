using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace ApiServices.EmployeeAssignment
{
    public class EmployeeAssignmentApiService
    {
        private readonly HttpClient _http;
        private readonly string _root = "https://localhost:7128/api/EmployeeAssignments";

        public EmployeeAssignmentApiService()
        {
            var handler = new HttpClientHandler();
            handler.ServerCertificateCustomValidationCallback = (m,c,ch,e) => true; 
            _http = new HttpClient(handler) { Timeout = TimeSpan.FromSeconds(15) };
        }

        public async Task<ApiResponse<List<EmployeeAssignmentDetailDto>>?> GetDetailsAsync()
        {
            var resp = await _http.GetAsync(_root + "/GetDetails");
            return await resp.Content.ReadFromJsonAsync<ApiResponse<List<EmployeeAssignmentDetailDto>>>();
        }

        public async Task<ApiResponse<object>?> AddOrReplaceAsync(EmployeeAssignmentUpsertDto dto)
        {
            var resp = await _http.PostAsJsonAsync(_root + "/AddOrReplaceActive", dto);
            return await resp.Content.ReadFromJsonAsync<ApiResponse<object>>();
        }

        public async Task<ApiResponse<object>?> UpdateAsync(EmployeeAssignmentUpdateDto dto)
        {
            var resp = await _http.PostAsJsonAsync(_root + "/Update", dto);
            return await resp.Content.ReadFromJsonAsync<ApiResponse<object>>();
        }
    }

    public class EmployeeAssignmentDetailDto
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public string EmployeeFullName { get; set; } = string.Empty;
        public int BranchId { get; set; }
        public string BranchName { get; set; } = string.Empty;
        public int DepartmentId { get; set; }
        public string DepartmentName { get; set; } = string.Empty;
        public int PositionId { get; set; }
        public string PositionName { get; set; } = string.Empty;
        public DateTime HireDate { get; set; }
        public DateTime? TerminationDate { get; set; }
        public bool IsActive => TerminationDate == null;
    }

    public class EmployeeAssignmentUpsertDto
    {
        public int EmployeeId { get; set; }
        public int DepartmentId { get; set; }
        public int PositionId { get; set; }
        public DateTime HireDate { get; set; }
    }

    public class EmployeeAssignmentUpdateDto : EmployeeAssignmentUpsertDto
    {
        public int Id { get; set; }
        public DateTime? TerminationDate { get; set; }
    }

    public class ApiResponse<T>
    {
        public bool Success { get; set; }
        public string Message { get; set; } = string.Empty;
        public T? Data { get; set; }
    }
}
