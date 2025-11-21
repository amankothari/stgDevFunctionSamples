using System.IO;
using System.Threading.Tasks;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;

namespace ProcessBlobFile.Function;

public class ProcessBlobFile
{
    private readonly ILogger<ProcessBlobFile> _logger;

    public ProcessBlobFile(ILogger<ProcessBlobFile> logger)
    {
        _logger = logger;
    }

    [Function(nameof(ProcessBlobFile))]
    public async Task Run([BlobTrigger("samples-workitems/{name}", Connection = "1b9182_STORAGE")] Stream stream, string name)
    {
        using var blobStreamReader = new StreamReader(stream);
        var content = await blobStreamReader.ReadToEndAsync();
        _logger.LogInformation("C# Blob Trigger (using Event Grid) processed blob\n Name: {name} \n Data: {content}", name, content);
    }
}
