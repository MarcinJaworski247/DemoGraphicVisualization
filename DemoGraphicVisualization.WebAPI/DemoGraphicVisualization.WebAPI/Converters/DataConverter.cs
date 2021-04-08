using DemoGraphicVisualization.WebAPI.DTO;
using DemoGraphicVisualization.WebAPI.VM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoGraphicVisualization.WebAPI.Converters
{
    public class DataConverter
    {
        public List<PopulationDataChartVM> ConvertPopulationDataToChart(RestApiDataDTO data)
        {
            Dictionary<string, int> nationIndexes = data.Dimensions.Geo.Category.Indexes;
            Dictionary<string, string> nationLabels = data.Dimensions.Geo.Category.Labels;

            Dictionary<string, int> values = data.Values;

            List<PopulationDataChartVM> result = values.Select(x => new PopulationDataChartVM()
            {
                Nation = x.Key,
                Population = x.Value
            }).ToList();

            foreach(var item in result)
            {
                item.Nation = nationIndexes.Where(x => x.Value.ToString() == item.Nation).Select(x => x.Key).FirstOrDefault();
            }

            return result;
        }
        public List<PopulationDataMapVM> ConvertPopulationDataToMap(RestApiDataDTO data)
        {
            Dictionary<string, int> nationIndexes = data.Dimensions.Geo.Category.Indexes;
            Dictionary<string, int> values = data.Values;

            List<PopulationDataMapVM> result = values.Select(x => new PopulationDataMapVM()
            {
                Nation = x.Key,
                Population = x.Value
            }).ToList();

            foreach (var item in result)
            {
                item.Nation = nationIndexes.Where(x => x.Value.ToString() == item.Nation).Select(x => x.Key).FirstOrDefault();
            }

            return result;
        }
    }
}
