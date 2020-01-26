using PruebaService_App.Contracts.HttpClients;
using PruebaService_Common.Configurations;
using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using static System.ExceptionExtensions;

namespace PruebaService_App.Services.HttpClients
{
    public class PruebaHttpClientService : IPruebaHttpClient
    {
        private readonly HttpClient _client;
        private readonly Resources _resources;

        public PruebaHttpClientService(HttpClient client, PruebaEndpointConfig endpoints)
        {
            _client = client;
            _resources = endpoints.Resources;
        }

        public async Task<(string, HttpStatusCode)> GetPeople() =>
            await UseCatchExceptionAsync<(string, HttpStatusCode), HttpClientException>(
                async execError =>
                {
                    var response = await _client.GetAsync(_resources.People);
                    return (await response.Content.ReadAsStringAsync(), response.StatusCode);
                },
                $"Ha ocurrido al momento de consumir el recurso {_resources.People}");

        public async Task<(string, HttpStatusCode)> GetPlanets() =>
            await UseCatchExceptionAsync<(string, HttpStatusCode), HttpClientException>(
                async execError =>
                {
                    var response = await _client.GetAsync(_resources.Planet);
                    return (await response.Content.ReadAsStringAsync(), response.StatusCode);
                },
                $"Ha ocurrido al momento de consumir el recurso {_resources.Planet}");
    }
}
