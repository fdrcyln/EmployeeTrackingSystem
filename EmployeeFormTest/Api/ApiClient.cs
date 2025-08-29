using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace EmployeeFormTest.Api
{
    internal static class ApiClient
    {
        private static readonly HttpClient _httpClient = Create();
        public static string BaseUrl { get; set; } = "https://localhost:7128/api";

        private static HttpClient Create()
        {
            var handler = new HttpClientHandler
            {
                ServerCertificateCustomValidationCallback = (msg, cert, chain, errors) => true
            };
            return new HttpClient(handler) { Timeout = TimeSpan.FromSeconds(15) };
        }

        // Minimal local ApiResponse definition
        public class ApiResponse<T>
        {
            public bool Success { get; set; }
            public string Message { get; set; } = string.Empty;
            public T? Data { get; set; }
        }

        public static async Task<ApiResponse<T>?> GetAsync<T>(string relative)
        {
            var resp = await _httpClient.GetAsync(Combine(relative));
            return await resp.Content.ReadFromJsonAsync<ApiResponse<T>>();
        }

        public static async Task<ApiResponse<TResp>?> PostAsync<TReq, TResp>(string relative, TReq body)
        {
            var resp = await _httpClient.PostAsJsonAsync(Combine(relative), body);
            return await resp.Content.ReadFromJsonAsync<ApiResponse<TResp>>();
        }

        public static async Task<ApiResponse<object>?> DeleteAsync(string relative)
        {
            var resp = await _httpClient.DeleteAsync(Combine(relative));
            return await resp.Content.ReadFromJsonAsync<ApiResponse<object>>();
        }

        private static string Combine(string relative) => BaseUrl.TrimEnd('/') + "/" + relative.TrimStart('/');
    }
}
