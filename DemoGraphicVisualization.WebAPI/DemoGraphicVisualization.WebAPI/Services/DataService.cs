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
        public DataService(IRestApiService restApiService)
        {
            this.restApiService = restApiService;
            this.dataConverter = new DataConverter();
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

            return populationDataVM;
        }
        public List<PopulationTreeMapVM> GetPopulationDataToTreeMap(string year)
        {
            RestApiPopulationDataDTO restApiData = restApiService.GetPopulationData();
            List<PopulationDataTreeMapVM> populationDataVM = dataConverter.ConvertPopulationDataToTreeMap(restApiData, year);
            List<PopulationTreeMapVM> result = new List<PopulationTreeMapVM>();
            PopulationTreeMapVM populationTreeMapVM = new PopulationTreeMapVM
            {
                Name = "Europe",
                Items = populationDataVM
            };
            result.Add(populationTreeMapVM);

            return result;
        }
        public PopulationDataGraphVM GetPopulationDataToGraph(string year)
        {
            RestApiPopulationDataDTO restApiData = restApiService.GetPopulationData();
            List<PopulationDataChartVM> populationDataVM = dataConverter.ConvertPopulationDataToChart(restApiData, year);
            PopulationDataGraphVM result = new PopulationDataGraphVM();
            foreach(var item in populationDataVM)
            {
                if (item.Population != null && item.Population != 0)
                {
                    result.Nodes.Add(new GraphNodeVM
                    {
                        Id = item.Nation
                    });
                    result.Links.Add(new GraphLinkVM
                    {
                        Target = item.Nation,
                        Population = item.Population
                    });
                }
            }
            foreach(var res in result.Nodes)
            {
                if (res.Id.StartsWith("Germany")) res.Id = "Germany";
                if (res.Id.StartsWith("Kosovo")) res.Id = "Kosovo";
            }
            foreach(var re in result.Links)
            {
                if (re.Source.StartsWith("Germany")) re.Source = "Germany";
                if (re.Target.StartsWith("Germany")) re.Target = "Germany";

                if (re.Source.StartsWith("Kosovo")) re.Source = "Kosovo";
                if (re.Target.StartsWith("Kosovo")) re.Target = "Kosovo";

                
            }
            return result;
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
