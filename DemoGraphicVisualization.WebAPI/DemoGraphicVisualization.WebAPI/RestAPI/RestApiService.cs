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
        public PopulationDataDTO GetPopulationData()
        {
            IRestClient restClient = new RestClient();
            IRestRequest restRequest = new RestRequest
                ("http://ec.europa.eu/eurostat/wdds/rest/data/v2.1/json/en/tps00001?precision=1");
            restRequest.AddHeader("Accept", "application/json");

            IRestResponse<PopulationDataDTO> restResponse = restClient.Get<PopulationDataDTO>(restRequest);

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
