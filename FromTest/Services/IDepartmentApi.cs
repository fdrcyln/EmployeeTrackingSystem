using System.Net.Http.Json;

namespace FromTest;

public interface IDepartmentApi
{
    Task<DataResult<List<DepartmentDto>>> GetAllAsync(CancellationToken ct = default);
}

public class DepartmentApi : IDepartmentApi
{
    private readonly IHttpClientFactory _clientFactory;
    public DepartmentApi(IHttpClientFactory clientFactory) => _clientFactory = clientFactory;

    public async Task<DataResult<List<DepartmentDto>>> GetAllAsync(CancellationToken ct = default)
    {
        var client = _clientFactory.CreateClient("api");
        try
        {
            return await client.GetFromJsonAsync<DataResult<List<DepartmentDto>>>("api/departments", ct)
                   ?? new DataResult<List<DepartmentDto>> { Success = false, Message = "Boþ cevap" };
        }
        catch (Exception ex)
        {
            return new DataResult<List<DepartmentDto>> { Success = false, Message = ex.Message };
        }
    }
}
