using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;

namespace Motown.API;

public class GetArtists
{
    private readonly ILogger<GetArtists> _logger;

    public GetArtists(ILogger<GetArtists> logger)
    {
        _logger = logger;
    }

    [FunctionName("GetArtists")]
    public static async Task<IActionResult> Run(
    [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = null)] HttpRequest req,
    ILogger log)
    {
        using (var db = new MotownDbContext())
        {
            return new OkObjectResult(db.Artists.ToList());
        }
    }
}