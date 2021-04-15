using DemoGraphicVisualization.WebAPI.DTO;
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
        public List<Value> GetBaseStructure(RestApiDataDTO data, string year)
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
        public List<PopulationDataChartVM> ConvertPopulationDataToChart(RestApiDataDTO data, string year)
        {

            List<Value> values = GetBaseStructure(data, year);
            List<PopulationDataChartVM> result = values.Select(x => new PopulationDataChartVM
            {
                Nation = x.Nation != null ? x.Nation.Value : "",
                Population = x.Population,
                Year = x.Time.Value
            }).ToList();

            return result;
        }
        public Dictionary<string, long> ConvertPopulationDataToMap(RestApiDataDTO data, string year)
        {
            List<Value> values = GetBaseStructure(data, year);
            //Dictionary<string, long> result = values.Select(x => new Dictionary<string, long>
            //{
            //    Key = x.Nation.Value,
            //    Value = x.Population
            //}).tod();

            Dictionary<string, long> result = values.ToDictionary(x => x.Nation.Value, x => x.Population);

            return result;
        }
    }
}
