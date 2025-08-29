using System.Net.Http.Json;

namespace FromTest;

public interface IAssignmentApi
{
    Task<DataResult<List<AssignmentDto>>> GetAllAsync(CancellationToken ct = default);
}

public class AssignmentApi : IAssignmentApi
{
    private readonly IHttpClientFactory _clientFactory;
    public AssignmentApi(IHttpClientFactory clientFactory) => _clientFactory = clientFactory;

    public async Task<DataResult<List<AssignmentDto>>> GetAllAsync(CancellationToken ct = default)
    {
        var client = _clientFactory.CreateClient("api");
        try
        {
            return await client.GetFromJsonAsync<DataResult<List<AssignmentDto>>>("api/assignments", ct)
                   ?? new DataResult<List<AssignmentDto>> { Success = false, Message = "Boþ cevap" };
        }
        catch (Exception ex)
        {
            return new DataResult<List<AssignmentDto>> { Success = false, Message = ex.Message };
        }
    }
}
