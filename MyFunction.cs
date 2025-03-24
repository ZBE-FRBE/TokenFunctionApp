using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;
using System.Net;

public class MyFunction
{
    private readonly IGTokenService _tokenService;
    private readonly ILogger<MyFunction> _logger;

    public MyFunction(IGTokenService tokenService, ILogger<MyFunction> logger)
    {
        _tokenService = tokenService;
        _logger = logger;
    }

    [Function("MyFunction")]
    public async Task<HttpResponseData> Run(
        [HttpTrigger(AuthorizationLevel.Function, "get")] HttpRequestData req)
    {
        _logger.LogInformation("Handling request to retrieve IG token.");
        var token = await _tokenService.GetTokenAsync();

        var response = req.CreateResponse(HttpStatusCode.OK);
        response.WriteString($"IG Token: {token}");
        return response;
    }
}
