namespace FromTest;

public class TokenStore
{
    public string? AccessToken { get; private set; }
    public string? UserName { get; private set; }

    public void Set(string token, string userName)
    {
        AccessToken = token;
        UserName = userName;
    }

    public void Clear()
    {
        AccessToken = null;
        UserName = null;
    }
}
