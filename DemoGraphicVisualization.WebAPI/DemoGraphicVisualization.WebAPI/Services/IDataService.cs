using DemoGraphicVisualization.WebAPI.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoGraphicVisualization.WebAPI.Services
{
    public interface IDataService
    {
        PopulationDataDTO GetPopulationData();
    }
}
