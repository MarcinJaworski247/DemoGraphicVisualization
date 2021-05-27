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

            List<MigrationAverageVM> avg = GetMigrationAverage(migrationType);
            foreach(var res in result)
            {
                res.Average = avg.Where(x => x.Year == res.Year).Select(x => x.Average).FirstOrDefault();
            }

            return result;
        }
        public List<AssaultsDataChartVM> GetAssaultsDataToChart(string nation)
        {
            RestApiAssaultsDataDTO assaults = restApiService.GetAssaultsPerHundredData();
            List<AssaultsDataChartVM> result = dataConverter.ConvertAssaultsDataToChart(assaults, nation);
            return result;
        }
        public List<HealthyLifeDataChartVM> GetHealthyLifeDataToChart(string nation)
        {
            RestApiHealthyLifeDataDTO healthyLife = restApiService.GetHealfyLifeExceptationData();
            List<HealthyLifeDataChartVM> result = dataConverter.ConverthealthyLifeDataToChart(healthyLife, nation);
            return result;
        }
        public List<MigrationAverageVM> GetMigrationAverage(MigrationType migrationType)
        {
            RestApiMigrationDataDTO migration = new RestApiMigrationDataDTO();
            switch (migrationType)
            {
                case MigrationType.Emigration:
                    migration = restApiService.GetEmigrationData();
                    break;
                case MigrationType.Immigration:
                    migration = restApiService.GetImmigrationData();
                    break;
            }

            List<Converters.Time> times = migration.Dimensions.Time.TimeCategory.Indexes.Select(x => new Converters.Time
            {
                Key = x.Value,
                Value = x.Key
            }).ToList();

            List<Value> values = new List<Value>();
            for (int x = 0; x <= 791; x++)
            {
                values.Add(new Value(x.ToString()));
            }

            for (int x = 0; x < values.Count; x++)
            {
                values[x].Population = migration.Values.Where(y => y.Key == values[x].Key).Select(y => y.Value).FirstOrDefault();
            }

            int i = 0;
            while (i < values.Count)
            {
                for (int u = 0; u < times.Count; u++)
                {
                    if (i < values.Count)
                    {
                        values[i].Time = times[u];
                        i++;
                    }
                }
            }

            List<MigrationAverageVM> result = new List<MigrationAverageVM>();
            foreach(var time in times)
            {
                MigrationAverageVM migrationAverage = new MigrationAverageVM
                {
                    Year = time.Value,
                    Average = Math.Round(values.Where(x => x.Time.Value.Equals(time.Value) && x.Population != 0).Average(x => x.Population),2)
                };
                result.Add(migrationAverage);
            }

            return result;
        }
    }
}
