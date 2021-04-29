using DemoGraphicVisualization.WebAPI.DTO;
using DemoGraphicVisualization.WebAPI.Enums;
using DemoGraphicVisualization.WebAPI.Helpers;
using DemoGraphicVisualization.WebAPI.VM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoGraphicVisualization.WebAPI.Converters
{
    public class Nation
    {
        public int Key { get; set; }
        public string Value { get; set; }
        public string Shortcut { get; set; }

        public Nation(int key, string value, string shortcut)
        {
            Key = key;
            Value = value;
            Shortcut = shortcut;
        }
        public Nation()
        {
        }
    }
    public class Time
    {
        public int Key { get; set; }
        public string Value { get; set; }
        public Time(int key, string value)
        {
            Key = key;
            Value = value;
        }
        public Time()
        {

        }
    }
    public class Value
    {
        public string Key { get; set; }
        public long Population { get; set; }
        public string Status { get; set; }
        public Nation? Nation { get; set; }
        public Time? Time { get; set; }
        public Value(string key)
        {
            Key = key;
        }
    }
    public class DataConverter
    {
        public List<Value> GetPopulationBaseStructure(RestApiPopulationDataDTO data, string year)
        {
            // nations full list
            List<Nation> nations = data.Dimensions.Geo.Category.Indexes.Select(x => new Nation
            {
                Key = x.Value,
                Shortcut = x.Key
            }).ToList();

            foreach (var item in nations)
            {
                item.Value = data.Dimensions.Geo.Category.Labels.Where(x => x.Key == item.Shortcut).Select(x => x.Value).FirstOrDefault();
            }

            // times full list
            List<Time> times = data.Dimensions.Time.TimeCategory.Indexes.Select(x => new Time
            {
                Key = x.Value,
                Value = x.Key
            }).ToList();

            // values init
            List<Value> values = new List<Value>();
            for(int x = 0; x <= 658; x++)
            {
                values.Add(new Value(x.ToString()));
            }
            
            // set population
            for(int x = 0; x < values.Count; x++)
            {
                values[x].Population = data.Values.Where(y => y.Key == values[x].Key).Select(y => y.Value).FirstOrDefault();
            }

            // set time
            int i = 0;
            while(i < values.Count)
            {
                for(int u = 0; u < times.Count; u++)
                {
                    if (i < values.Count)
                    {
                        values[i].Time = times[u];
                        i++;
                    }
                }
            }

            // set nation


            values = values.Where(x => x.Time.Value == year).ToList();
            for(int q = 0; q < values.Count; q++)
            {
                values[q].Nation = nations[q];
            }

            values.RemoveAll(x => x.Nation.Value.StartsWith("European Union") || x.Nation.Value.StartsWith("Euro area"));

            return values;
        }
        public List<PopulationDataChartVM> ConvertPopulationDataToChart(RestApiPopulationDataDTO data, string year)
        {

            List<Value> values = GetPopulationBaseStructure(data, year);
            List<PopulationDataChartVM> result = values.Select(x => new PopulationDataChartVM
            {
                Nation = x.Nation != null ? x.Nation.Value : "",
                Population = x.Population,
                Year = x.Time.Value
            }).ToList();

            return result;
        }
        public List<PopulationDataTreeMapVM> ConvertPopulationDataToTreeMap(RestApiPopulationDataDTO data, string year)
        {
            List<Value> values = GetPopulationBaseStructure(data, year);
            List<PopulationDataTreeMapVM> result = values.Select(x => new PopulationDataTreeMapVM
            {
                Name = x.Nation.Value,
                Value = x.Population
            }).ToList();

            return result;
        }
        public Dictionary<string, long> ConvertPopulationDataToMap(RestApiPopulationDataDTO data, string year)
        {
            List<Value> values = GetPopulationBaseStructure(data, year);
            //Dictionary<string, long> result = values.Select(x => new Dictionary<string, long>
            //{
            //    Key = x.Nation.Value,
            //    Value = x.Population
            //}).tod();

            Dictionary<string, long> result = values.ToDictionary(x => x.Nation.Value, x => x.Population);

            return result;
        }
        public List<Value> GetMigrationBaseStructure(RestApiMigrationDataDTO data, string year)
        {
            // nations full list
            List<Nation> nations = data.Dimensions.Geo.Category.Indexes.Select(x => new Nation
            {
                Key = x.Value,
                Shortcut = x.Key
            }).ToList();

            foreach (var item in nations)
            {
                item.Value = data.Dimensions.Geo.Category.Labels.Where(x => x.Key == item.Shortcut).Select(x => x.Value).FirstOrDefault();
            }

            // times full list
            List<Time> times = data.Dimensions.Time.TimeCategory.Indexes.Select(x => new Time
            {
                Key = x.Value,
                Value = x.Key
            }).ToList();

            // values init
            List<Value> values = new List<Value>();
            for (int x = 0; x <= 791; x++)
            {
                values.Add(new Value(x.ToString()));
            }

            // set population
            for (int x = 0; x < values.Count; x++)
            {
                values[x].Population = data.Values.Where(y => y.Key == values[x].Key).Select(y => y.Value).FirstOrDefault();
            }

            // set time
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

            values.RemoveAll(x => Convert.ToInt32(x.Key) >395);

            // set nation
            values = values.Where(x => x.Time.Value == year).ToList();
            for (int q = 0; q < values.Count; q++)
            {
                values[q].Nation = nations[q];
            }

            

            values.RemoveAll(x => x.Nation.Value.StartsWith("European Union") || x.Nation.Value.StartsWith("Euro area"));

            return values;
        }
        public List<MigrationDataChartVM> ConvertMigrationDataToChart(RestApiMigrationDataDTO immigration, RestApiMigrationDataDTO emigration, string year, string[] nations)
        {
            List<Value> immigrationData = GetMigrationBaseStructure(immigration, year);
            List<Value> emigrationData = GetMigrationBaseStructure(emigration, year);

            List<MigrationDataChartVM> result = immigrationData.Select(x => new MigrationDataChartVM
            {
                Nation = x.Nation != null ? x.Nation.Value : "",
                Immigration = x.Population
            }).ToList();

            foreach(var item in result)
            {
                item.Emigration = emigrationData.Where(x => x.Nation.Value.Equals(item.Nation)).Select(x => x.Population).FirstOrDefault();
            }

            if(nations.Count() > 0)
            {
                return result.Where(x => nations.Contains(x.Nation)).ToList();
            }



            return result;
        }
        public List<ValueBinder<string, string>> ConvertMigrationDataToNationsLookup(RestApiMigrationDataDTO data)
        {
            List<Nation> nations = data.Dimensions.Geo.Category.Indexes.Select(x => new Nation
            {
                Key = x.Value,
                Shortcut = x.Key
            }).ToList();

            foreach (var item in nations)
            {
                item.Value = data.Dimensions.Geo.Category.Labels.Where(x => x.Key == item.Shortcut).Select(x => x.Value).FirstOrDefault();
            }

            List<ValueBinder<string, string>> result = nations.Select(x => new ValueBinder<string, string>()
            {
                Key = x.Value,
                Value = x.Value
            }).ToList();

            return result;
        }
        public List<NationMigrationChartDataVM> ConvertMigrationDataToNationChart(RestApiMigrationDataDTO immigration, RestApiMigrationDataDTO emigration, string nation, MigrationType migrationType)
        {
            RestApiMigrationDataDTO restApiData = migrationType switch
            {
                MigrationType.Immigration => immigration,
                MigrationType.Emigration => emigration,
                _ => throw new Exception(),
            };
            return ConvertMigrationData(restApiData, nation);
        }
        internal List<NationMigrationChartDataVM> ConvertMigrationData(RestApiMigrationDataDTO data, string nation)
        {
            // nations full list
            List<Nation> nations = data.Dimensions.Geo.Category.Indexes.Select(x => new Nation
            {
                Key = x.Value,
                Shortcut = x.Key
            }).ToList();

            foreach (var item in nations)
            {
                item.Value = data.Dimensions.Geo.Category.Labels.Where(x => x.Key == item.Shortcut).Select(x => x.Value).FirstOrDefault();
            }

            // times full list
            List<Time> times = data.Dimensions.Time.TimeCategory.Indexes.Select(x => new Time
            {
                Key = x.Value,
                Value = x.Key
            }).ToList();

            // values init
            List<Value> values = new List<Value>();
            for (int x = 0; x <= 791; x++)
            {
                values.Add(new Value(x.ToString()));
            }

            // set population
            for (int x = 0; x < values.Count; x++)
            {
                values[x].Population = data.Values.Where(y => y.Key == values[x].Key).Select(y => y.Value).FirstOrDefault();
            }

            values.RemoveAll(x => Convert.ToInt32(x.Key) > 395);

            // set time
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

            int it = 0;
            for(int w = 0; w < nations.Count; w++)
            {
                List<Value> tmp = values.Skip(it).Take(12).ToList();
                foreach(var kurwaMacMamDosc in tmp)
                {
                    kurwaMacMamDosc.Nation = nations[w];
                }
                it += 12;
            }

            List<NationMigrationChartDataVM> result = values.Where(x => x.Nation.Value.Equals(nation)).Select(x => new NationMigrationChartDataVM()
            {
                Migration = x.Population
            }).ToList();

            for(int v = 0; v < times.Count; v++)
            {
                result[v].Year = times[v].Value;
            }

            for(int t = 0; t < result.Count; t++)
            {
                if (t == 0)
                    result[t].Change = 0.0D;
                else if(result[t-1].Migration != 0)
                    result[t].Change = ((Convert.ToDouble(result[t].Migration) / Convert.ToDouble(result[t - 1].Migration)) - 1) * 100;
            }

            return result;
        }
    }
}
