using DemoGraphicVisualization.WebAPI.DTO;
using DemoGraphicVisualization.WebAPI.RestAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoGraphicVisualization.WebAPI.Services
{
    public class DataService : IDataService
    {
        private readonly IRestApiService restApiService;
        public DataService(IRestApiService restApiService)
        {
            this.restApiService = restApiService;
        }
        public PopulationDataDTO GetPopulationData()
        {
            return restApiService.GetPopulationData();
        }
    }
}
