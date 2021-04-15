using DemoGraphicVisualization.WebAPI.DTO;
using DemoGraphicVisualization.WebAPI.VM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoGraphicVisualization.WebAPI.Services
{
    public interface IDataService
    {
        List<PopulationDataChartVM> GetPopulationDataToChart(string year);
        Dictionary<string, long> GetPopulationDataToMap(string year);
    }
}
