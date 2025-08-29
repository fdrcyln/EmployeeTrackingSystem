using System.Net.Http.Json;

namespace FromTest;

public interface IPositionApi
{
    Task<DataResult<List<PositionDto>>> GetAllAsync(CancellationToken ct = default);
}

public class PositionApi : IPositionApi
{
    private readonly IHttpClientFactory _clientFactory;
    public PositionApi(IHttpClientFactory clientFactory) => _clientFactory = clientFactory;

    public async Task<DataResult<List<PositionDto>>> GetAllAsync(CancellationToken ct = default)
    {
        var client = _clientFactory.CreateClient("api");
        try
        {
            return await client.GetFromJsonAsync<DataResult<List<PositionDto>>>("api/positions", ct)
                   ?? new DataResult<List<PositionDto>> { Success = false, Message = "Boþ cevap" };
        }
        catch (Exception ex)
        {
            return new DataResult<List<PositionDto>> { Success = false, Message = ex.Message };
        }
    }
}
