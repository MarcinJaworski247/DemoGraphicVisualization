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
        public List<PopulationDataChartVM> GetPopulationDataToChart()
        {
            RestApiDataDTO restApiData = restApiService.GetPopulationData();
            List<PopulationDataChartVM> populationDataVM = dataConverter.ConvertPopulationDataToChart(restApiData);

            return populationDataVM;
        }
        public List<PopulationDataMapVM> GetPopulationDataToMap()
        {
            RestApiDataDTO restApiData = restApiService.GetPopulationData();
            List<PopulationDataMapVM> populationDataVM = dataConverter.ConvertPopulationDataToMap(restApiData);
            foreach(var item in populationDataVM)
            {
                item.Color = colors.GetRandomHTMLColor();
            }

            return populationDataVM;
        }
    }
}
