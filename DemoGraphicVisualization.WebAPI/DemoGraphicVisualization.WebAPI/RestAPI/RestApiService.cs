using DemoGraphicVisualization.WebAPI.DTO;
using RestSharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace DemoGraphicVisualization.WebAPI.RestAPI
{
    public class RestApiService : IRestApiService
    {
        public RestApiPopulationDataDTO GetPopulationData()
        {
            IRestClient restClient = new RestClient();
            IRestRequest restRequest = new RestRequest
                ("http://ec.europa.eu/eurostat/wdds/rest/data/v2.1/json/en/tps00001?precision=1");
            restRequest.AddHeader("Accept", "application/json");

            IRestResponse<RestApiPopulationDataDTO> restResponse = restClient.Get<RestApiPopulationDataDTO>(restRequest);

            if (restResponse.IsSuccessful)
            {
                return restResponse.Data;
            }
            else
            {
                return null;
            }
        }
        public RestApiMigrationDataDTO GetImmigrationData()
        {
            IRestClient restClient = new RestClient();
            IRestRequest restRequest = new RestRequest
                ("http://ec.europa.eu/eurostat/wdds/rest/data/v2.1/json/en/tps00176?precision=1");
            restRequest.AddHeader("Accept", "application/json");

            IRestResponse<RestApiMigrationDataDTO> restResponse = restClient.Get<RestApiMigrationDataDTO>(restRequest);

            if (restResponse.IsSuccessful)
            {
                return restResponse.Data;
            }
            else
            {
                return null;
            }
        }

        public RestApiMigrationDataDTO GetEmigrationData()
        {
            IRestClient restClient = new RestClient();
            IRestRequest restRequest = new RestRequest
                ("http://ec.europa.eu/eurostat/wdds/rest/data/v2.1/json/en/tps00177?precision=1");
            restRequest.AddHeader("Accept", "application/json");

            IRestResponse<RestApiMigrationDataDTO> restResponse = restClient.Get<RestApiMigrationDataDTO>(restRequest);

            if (restResponse.IsSuccessful)
            {
                return restResponse.Data;
            }
            else
            {
                return null;
            }
        }
    }
}
