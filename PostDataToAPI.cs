using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;

namespace PostDataAPI.Function;

public class PostDataToAPI
{
    private readonly ILogger<PostDataToAPI> _logger;

    public PostDataToAPI(ILogger<PostDataToAPI> logger)
    {
        _logger = logger;
    }

    [Function("PostDataToAPI")]
    public IActionResult Run([HttpTrigger(AuthorizationLevel.Admin, "get", "post")] HttpRequest req)
    {
        _logger.LogInformation("C# HTTP trigger function processed a request.");
        return new OkObjectResult("Welcome to Azure Functions!");
    }
}