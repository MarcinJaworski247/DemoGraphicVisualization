using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace DemoGraphicVisualization.WebAPI.RestAPI
{
    public class RestApiService : IRestApiService
    {
        private readonly IHttpClientFactory _clientFactory;
        public RestApiService(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }
        public async Task<List<object>> GetTestData()
        {
            var request = new HttpRequestMessage(HttpMethod.Get,
            "http://ec.europa.eu/eurostat/wdds/rest/data/v2.1/json/en/tps00001?precision=1");
            //request.Headers.Add("Accept", "application/vnd.github.v3+json");
            //request.Headers.Add("User-Agent", "HttpClientFactory-Sample");

            var client = _clientFactory.CreateClient();

            var response = await client.SendAsync(request);

            List<object> data = new List<object>();

            if (response.IsSuccessStatusCode)
            {
                using var responseStream = await response.Content.ReadAsStreamAsync();
                data = await JsonSerializer.DeserializeAsync
                    <List<object>>(responseStream);
            }

            return data;
        }
    }
}
