using static microService.Services.ApiClient;

namespace microService.Services
{
    public interface IApiClient
    {
        CoinsInfo ConnectToApi(string currency);
    }
}
