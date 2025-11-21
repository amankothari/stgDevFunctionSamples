using System.IO;
using System.Threading.Tasks;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;

namespace ProcessBlob.Function;

public class ProcessBlob
{
    private readonly ILogger<ProcessBlob> _logger;

    public ProcessBlob(ILogger<ProcessBlob> logger)
    {
        _logger = logger;
    }

    [Function(nameof(ProcessBlob))]
    public async Task Run([BlobTrigger("samples-workitems/{name}", Connection = "AzureWebJobsStorage")] Stream stream, string name)
    {
        using var blobStreamReader = new StreamReader(stream);
        var content = await blobStreamReader.ReadToEndAsync();
        _logger.LogInformation("C# Blob trigger function Processed blob\n Nameeeeeeeeeeee: {name} \n Data: {content}", name, content);
    }
}