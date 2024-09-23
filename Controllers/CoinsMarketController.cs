using Microsoft.AspNetCore.Mvc;

namespace microService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CoinsMarketController : ControllerBase
    {
        

        public CoinsMarketController(
ILogger<CoinsMarketController> logger,
IApiClient apiClient
)
{

_apiClient = apiClient;
_logger = logger;

}

[HttpGet]
[Route("{currency}")]
public IActionResult Get(string currency)
{

var result = _apiClient. ConnectToApi(currency);
return Ok(result);
    }
}
