using DemoGraphicVisualization.WebAPI.Converters;
using DemoGraphicVisualization.WebAPI.DTO;
using DemoGraphicVisualization.WebAPI.Helpers;
using DemoGraphicVisualization.WebAPI.RestAPI;
using DemoGraphicVisualization.WebAPI.VM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoGraphicVisualization.WebAPI.Services
{
    public class DataService : IDataService
    {
        private readonly IRestApiService restApiService;
        private readonly DataConverter dataConverter;
        private readonly Colors colors;
        public DataService(IRestApiService restApiService)
        {
            this.restApiService = restApiService;
            this.dataConverter = new DataConverter();
            this.colors = new Colors();
        }
        public List<PopulationDataChartVM> GetPopulationDataToChart(string year)
        {
            RestApiDataDTO restApiData = restApiService.GetPopulationData();
            List<PopulationDataChartVM> populationDataVM = dataConverter.ConvertPopulationDataToChart(restApiData, year);

            return populationDataVM;
        }
        public Dictionary<string, long> GetPopulationDataToMap(string year)
        {
            RestApiDataDTO restApiData = restApiService.GetPopulationData();
            Dictionary<string, long> populationDataVM = dataConverter.ConvertPopulationDataToMap(restApiData, year);
            //foreach(var item in populationDataVM)
            //{
            //    item.Color = colors.GetRandomHTMLColor();
            //}

            return populationDataVM;
        }
    }
}
