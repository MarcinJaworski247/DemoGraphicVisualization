using DemoGraphicVisualization.WebAPI.Converters;
using DemoGraphicVisualization.WebAPI.DTO;
using DemoGraphicVisualization.WebAPI.Enums;
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
        //private readonly Colors colors;
        public DataService(IRestApiService restApiService)
        {
            this.restApiService = restApiService;
            this.dataConverter = new DataConverter();
           // this.colors = new Colors();
        }
        public List<PopulationDataChartVM> GetPopulationDataToChart(string year)
        {
            RestApiPopulationDataDTO restApiData = restApiService.GetPopulationData();
            List<PopulationDataChartVM> populationDataVM = dataConverter.ConvertPopulationDataToChart(restApiData, year);

            return populationDataVM;
        }
        public Dictionary<string, long> GetPopulationDataToMap(string year)
        {
            RestApiPopulationDataDTO restApiData = restApiService.GetPopulationData();
            Dictionary<string, long> populationDataVM = dataConverter.ConvertPopulationDataToMap(restApiData, year);
            //foreach(var item in populationDataVM)
            //{
            //    item.Color = colors.GetRandomHTMLColor();
            //}

            return populationDataVM;
        }
        public List<MigrationDataChartVM> GetMigrationDataToChart(string year, string[] nations)
        {
            RestApiMigrationDataDTO immigration = restApiService.GetImmigrationData();
            RestApiMigrationDataDTO emigration = restApiService.GetEmigrationData();
            List<MigrationDataChartVM> result = dataConverter.ConvertMigrationDataToChart(immigration, emigration, year, nations);

            return result;
        }
        public List<ValueBinder<string, string>> GetNationsToLookup()
        {
            RestApiMigrationDataDTO immigration = restApiService.GetImmigrationData();
            List<ValueBinder<string, string>> result = dataConverter.ConvertMigrationDataToNationsLookup(immigration);
            return result;
        }
        public List<NationMigrationChartDataVM> GetNationMigrationDataToChart(string nation, MigrationType migrationType)
        {
            RestApiMigrationDataDTO immigration = restApiService.GetImmigrationData();
            RestApiMigrationDataDTO emigration = restApiService.GetEmigrationData();
            List<NationMigrationChartDataVM> result = dataConverter.ConvertMigrationDataToNationChart(immigration, emigration, nation, migrationType);

            return result;
        }
    }
}
