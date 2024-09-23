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


        1 reference
private static readonly List<HttpStatusCode> invalidStatusCode = new List<HttpStatusCode> <
HttpStatusCode.BadRequest,
HttpStatusCode.BadGateway,
HttpStatusCode.InternalServerError,
HttpStatusCode.RequestTimeout,
HttpStatusCode.Forbidden,
HttpStatusCode.GatewayTimeout

        public CoinsInfo ConnectToApi(string currency)
        {
            //adding polly policies 
            var retryPolicy = Policy.HandleResult<IRestResponse>(resp => invalidStatusCode.Contains(resp.StatusCode)).WaitAndRetry(10, i => TimeSpan.FromSeconds(Math.Pow(2, i)), (result, TimeSpan, currentRetryCount, context) => {
                ;
            var client = new RestClient($"{_settings.CoinsPriceUrl}/ticker");

            // Initiate the Rest Request
            var request = new RestRequest(Method.GET);
            request.RequestFormat = DataFormat.Json;

            // Added the request params
            request.AddParameter("key", _settings.ApiKey, ParameterType.GetOrPost);
            request.AddParameter("label", "ethbtc-ltcbtc-btcbtc", ParameterType.GetOrPost);
            request.AddParameter("fiat", currency, ParameterType.GetOrPost);
                var policyResponse = retryPolicy.ExecuteAndCapture(() => {
                    return client.Get(request);

                    SampleService.csprof

}appsettings.json

C# IApiClient.cs

ApiClient.cs

C# ServiceSettings.cs

if (policyResponse.Result != null)

                    return JsonSerializer.Deserialize<CoinsInfo>(policyResponse.Result.Content);
            }else

                return null;

        }
        // calling the Api with all of the requests
        var response = client.Get(request);
            var markets = JsonSerializer.Deserialize<CoinsInfo>(response.Content);

            return markets;

        }
            public record Market(string Label, string Name, double Price);
            public record CoinsInfo(Market[] Markets);
    }
}
namespace Asyncronous;

internal class SomeAsyncOperations
{
    public string GetGithubPage()
    {
        var client = new HttpClient();
        var result = client.GetStringAsync("https://github.com/").Result;
        return result;
    }

    public async Task<string> GetGithubPageAsync()
    {
        var client = new HttpClient();
        var resultTask = await client.GetStringAsync("https://github.com/");
        return resultTask;
    }


    public object CallGitHubAndFaceBook()
    {
        var client = new HttpClient();

        var result = client.GetStringAsync("https://github.com/").Result; //5 seconds
        var result2 = client.GetStringAsync("https://facebook.com/").Result; //3 seconds

        return new { G = result, F = result2 };
    }

    public async Task<object> CallGitHubAndFaceBookAsync()
    {
        var client = new HttpClient();

        Task<string> result_Task = client.GetStringAsync("https://github.com/"); //5 seconds
        Task<string> result2_Task = client.GetStringAsync("https://facebook.com/"); //3 seconds

        var result = await result_Task;
        var result2 = await result2_Task;

        return new { G = result, F = result2 };
    }

}
