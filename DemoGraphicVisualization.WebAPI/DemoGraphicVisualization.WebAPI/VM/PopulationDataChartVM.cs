using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoGraphicVisualization.WebAPI.VM
{
    public class PopulationDataChartVM
    {
        public string  Nation { get; set; }
        public long? Population { get; set; }
        public string Year { get; set; }
    }
}
