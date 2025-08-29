using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;

namespace FromTest;

public class AuthHeaderHandler : DelegatingHandler
{
    private readonly TokenStore _tokenStore;

    public AuthHeaderHandler(TokenStore tokenStore) => _tokenStore = tokenStore;

    protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
    {
        if (!string.IsNullOrWhiteSpace(_tokenStore.AccessToken))
        {
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", _tokenStore.AccessToken);
        }
        return base.SendAsync(request, cancellationToken);
    }
}
