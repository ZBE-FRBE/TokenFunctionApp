using Microsoft.Extensions.Logging;
public class IGTokenService
{

    private readonly ILogger<IGTokenService> _logger;
    private readonly string _instanceId = Guid.NewGuid().ToString();
    private string? _token;
    private DateTime _expiresAt;

    public IGTokenService(ILogger<IGTokenService> logger)
    {
        _logger = logger;
    }

    public async Task<string> GetTokenAsync()
    {
        _logger.LogInformation($"[IGTokenService] Instance ID: {_instanceId}");

        _logger.LogInformation($"[_token value before check]: {_token ?? "null"}");

        if (_token == null || DateTime.UtcNow >= _expiresAt)
        {
            _token = await FetchTokenFromIGAsync();
            _expiresAt = DateTime.UtcNow.AddMinutes(5);
        }

        return _token;
    }

    private async Task<string> FetchTokenFromIGAsync()
    {
        await Task.Delay(100); // Simulate fetch delay
        return Guid.NewGuid().ToString(); // Replace with actual token logic
    }
}
