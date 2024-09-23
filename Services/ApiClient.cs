using microService.Configurations;
using Microsoft.Extensions.Options;
using RestSharp;
using System.Security.Cryptography.Xml;
using System.Text.Json;

namespace microService.Services
{
    public class ApiClient(IOptions<ServiceSettings> options) : IApiClient
    {
        private readonly ServiceSettings _settings = options.Value;

        public CoinsInfo ConnectToApi(string currency)
        {
            var client = new RestClient($"{_settings.CoinsPriceUrl}/ticker");

            // Initiate the Rest Request
            var request = new RestRequest(Method.GET);
            request.RequestFormat = DataFormat.Json;

            // Added the request params
            request.AddParameter("key", _settings.ApiKey, ParameterType.GetOrPost);
            request.AddParameter("label", "ethbtc-ltcbtc-btcbtc", ParameterType.GetOrPost);
            request.AddParameter("fiat", currency, ParameterType.GetOrPost);

            // calling the Api with all of the requests
            var response = client.Get(request);
            var markets = JsonSerializer.Deserialize<CoinsInfo>(response.Content);

            return markets;

        }
            public record Market(string Label, string Name, double Price);
            public record CoinsInfo(Market[] Markets);
    }
}
