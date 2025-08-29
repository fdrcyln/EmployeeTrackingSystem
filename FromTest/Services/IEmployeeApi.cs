using System.Net.Http.Json;

namespace FromTest;

public interface IEmployeeApi
{
    Task<DataResult<List<EmployeeDto>>> GetAllAsync(CancellationToken ct = default);
}

public class EmployeeApi : IEmployeeApi
{
    private readonly IHttpClientFactory _clientFactory;
    public EmployeeApi(IHttpClientFactory clientFactory) => _clientFactory = clientFactory;

    public async Task<DataResult<List<EmployeeDto>>> GetAllAsync(CancellationToken ct = default)
    {
        var client = _clientFactory.CreateClient("api");
        try
        {
            return await client.GetFromJsonAsync<DataResult<List<EmployeeDto>>>("api/employees", ct)
                   ?? new DataResult<List<EmployeeDto>> { Success = false, Message = "Boþ cevap" };
        }
        catch (Exception ex)
        {
            return new DataResult<List<EmployeeDto>> { Success = false, Message = ex.Message };
        }
    }
}
