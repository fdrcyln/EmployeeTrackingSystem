using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace ApiServices.Position
{
    public class PositionApiService
    {
        private readonly HttpClient _http;
        private readonly string _root = "https://localhost:7128/api"; 
        private static readonly JsonSerializerOptions _jsonOpt = new() { PropertyNameCaseInsensitive = true };

        public PositionApiService()
        {
            var handler = new HttpClientHandler();
            handler.ServerCertificateCustomValidationCallback = (m,c,ch,e) => true; 
            _http = new HttpClient(handler) { Timeout = TimeSpan.FromSeconds(15) };
        }

      
        public async Task<ApiResponse<List<PositionDto>>?> GetAllAsync()
        {
            string[] candidates = new[]
            {
                "/Positions/GetAll",
                "/Positions",            
                "/Position/GetAll",
                "/Position"              
            };
            List<string> errors = new();
            foreach (var path in candidates)
            {
                try
                {
                    var url = _root + path;
                    var resp = await _http.GetAsync(url);
                    if (!resp.IsSuccessStatusCode)
                    {
                        var errBody = await resp.Content.ReadAsStringAsync();
                        errors.Add(path + " => HTTP " + (int)resp.StatusCode + (string.IsNullOrWhiteSpace(errBody) ? "" : " BODY:" + Truncate(errBody, 200)));
                        continue;
                    }
                    var raw = await resp.Content.ReadAsStringAsync();
                    if (string.IsNullOrWhiteSpace(raw))
                        return new ApiResponse<List<PositionDto>> { Success = true, Data = new(), Message = "Boþ cevap (" + path + ")" };

                    
                    try
                    {
                        var wrapped = JsonSerializer.Deserialize<ApiResponse<List<PositionDto>>>(raw, _jsonOpt);
                        if (wrapped != null && wrapped.Data != null)
                        {
                            if (string.IsNullOrWhiteSpace(wrapped.Message)) wrapped.Message = "OK (" + path + ")";
                            return wrapped;
                        }
                    }
                    catch { /* ignore parse error */ }

                 
                    try
                    {
                        var list = JsonSerializer.Deserialize<List<PositionDto>>(raw, _jsonOpt) ?? new();
                        return new ApiResponse<List<PositionDto>> { Success = true, Data = list, Message = "OK (" + path + ")" };
                    }
                    catch (Exception ex)
                    {
                        errors.Add(path + " => JSON parse: " + ex.Message);
                        continue;
                    }
                }
                catch (Exception ex)
                {
                    errors.Add(path + " => Ex: " + ex.Message);
                }
            }
            return new ApiResponse<List<PositionDto>> { Success = false, Message = string.Join(" | ", errors), Data = new() };
        }

        public async Task<ApiResponse<PositionDto>?> AddAsync(PositionDto dto)
        {
            string[] candidates = { "/Positions/Add", "/Positions", "/Position/Add", "/Position" };
            return await PostPositionWithFallback(dto, candidates);
        }

        public async Task<ApiResponse<PositionDto>?> UpdateAsync(PositionDto dto)
        {
            string[] candidates = { "/Positions/Update", "/Position/Update", "/Positions", "/Position" };
            return await PostPositionWithFallback(dto, candidates);
        }

        public async Task<ApiResponse<object>?> DeleteAsync(int id)
        {
            string[] candidates = { $"/Positions/Delete/{id}", $"/Position/Delete/{id}", $"/Positions/{id}", $"/Position/{id}" };
            List<string> errs = new();
            foreach (var path in candidates)
            {
                try
                {
                    var resp = await _http.DeleteAsync(_root + path);
                    if (!resp.IsSuccessStatusCode)
                    {
                        var body = await resp.Content.ReadAsStringAsync();
                        errs.Add(path + " => HTTP " + (int)resp.StatusCode + (string.IsNullOrWhiteSpace(body) ? "" : " BODY:" + Truncate(body, 200)));
                        continue;
                    }
                    try
                    {
                        var api = await resp.Content.ReadFromJsonAsync<ApiResponse<object>>(_jsonOpt);
                        if (api != null) return api;
                    }
                    catch { }
                    return new ApiResponse<object> { Success = true, Message = "Silindi (" + path + ")" };
                }
                catch (Exception ex)
                {
                    errs.Add(path + " => Ex: " + ex.Message);
                }
            }
            return new ApiResponse<object> { Success = false, Message = string.Join(" | ", errs) };
        }

        private async Task<ApiResponse<PositionDto>?> PostPositionWithFallback(PositionDto dto, string[] candidates)
        {
            List<string> errs = new();
            foreach (var path in candidates)
            {
                try
                {
                    
                    var payload = new
                    {
                        dto.Id,
                        dto.Name,
                        Description = string.IsNullOrWhiteSpace(dto.Description) ? dto.Name : dto.Description,
                        DepartmantId = dto.DepartmentId 
                    };
                    var resp = await _http.PostAsJsonAsync(_root + path, payload);
                    if (!resp.IsSuccessStatusCode)
                    {
                        var body = await resp.Content.ReadAsStringAsync();
                        errs.Add(path + " => HTTP " + (int)resp.StatusCode + (string.IsNullOrWhiteSpace(body) ? "" : " BODY:" + Truncate(body, 200)));
                        continue;
                    }
                    try
                    {
                        var api = await resp.Content.ReadFromJsonAsync<ApiResponse<PositionDto>>(_jsonOpt);
                        if (api != null) return api;
                    }
                    catch { }
                    try
                    {
                        var raw = await resp.Content.ReadAsStringAsync();
                        if (!string.IsNullOrWhiteSpace(raw))
                        {
                            var dtoResp = JsonSerializer.Deserialize<PositionDto>(raw, _jsonOpt);
                            if (dtoResp != null)
                                return new ApiResponse<PositionDto> { Success = true, Data = dtoResp, Message = "OK (" + path + ")" };
                        }
                    }
                    catch { }
                    return new ApiResponse<PositionDto> { Success = true, Data = dto, Message = "OK (" + path + ")" };
                }
                catch (Exception ex)
                {
                    errs.Add(path + " => Ex: " + ex.Message);
                }
            }
            return new ApiResponse<PositionDto> { Success = false, Message = string.Join(" | ", errs) };
        }

        private static string Truncate(string s, int len) => s.Length <= len ? s : s[..len];
    }

    public class PositionDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty; 
        [JsonPropertyName("DepartmantId")] public int DepartmentId { get; set; }
    }

    public class ApiResponse<T>
    {
        public bool Success { get; set; }
        public string Message { get; set; } = string.Empty;
        public T? Data { get; set; }
    }
}
