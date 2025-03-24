public class IGTokenService
{
    private string? _token;
    private DateTime _expiresAt;

    public async Task<string> GetTokenAsync()
    {
        if (_token == null)
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
