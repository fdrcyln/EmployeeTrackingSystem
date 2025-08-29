using System.Net.Http.Json;

namespace FromTest;

public interface IBranchApi
{
    Task<DataResult<List<BranchDto>>> GetAllAsync(CancellationToken ct = default);
}

public class BranchApi : IBranchApi
{
    private readonly IHttpClientFactory _clientFactory;
    public BranchApi(IHttpClientFactory clientFactory) => _clientFactory = clientFactory;

    public async Task<DataResult<List<BranchDto>>> GetAllAsync(CancellationToken ct = default)
    {
        var client = _clientFactory.CreateClient("api");
        try
        {
            return await client.GetFromJsonAsync<DataResult<List<BranchDto>>>("api/branches", ct)
                   ?? new DataResult<List<BranchDto>> { Success = false, Message = "Boþ cevap" };
        }
        catch (Exception ex)
        {
            return new DataResult<List<BranchDto>> { Success = false, Message = ex.Message };
        }
    }
}
