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
        public RestApiAssaultsDataDTO GetAssaultsPerHundredData()
        {
            IRestClient restClient = new RestClient();
            IRestRequest restRequest = new RestRequest
                ("http://ec.europa.eu/eurostat/wdds/rest/data/v2.1/json/en/crim_off_cat?filterNonGeo=1&precision=2&unit=P_HTHAB&iccs=ICCS02011");
            restRequest.AddHeader("Accept", "application/json");

            IRestResponse<RestApiAssaultsDataDTO> restResponse = restClient.Get<RestApiAssaultsDataDTO>(restRequest);

            if (restResponse.IsSuccessful)
            {
                return restResponse.Data;
            }
            else
            {
                return null;
            }
        }
        public RestApiHealthyLifeDataDTO GetHealfyLifeExceptationData()
        {
            IRestClient restClient = new RestClient();
            IRestRequest restRequest = new RestRequest
                ("http://ec.europa.eu/eurostat/wdds/rest/data/v2.1/json/en/hlth_silc_17?indic_he=HE_BIRTH&filterNonGeo=1&precision=2&sex=T&unit=YR");
            restRequest.AddHeader("Accept", "application/json");

            IRestResponse<RestApiHealthyLifeDataDTO> restResponse = restClient.Get<RestApiHealthyLifeDataDTO>(restRequest);

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
