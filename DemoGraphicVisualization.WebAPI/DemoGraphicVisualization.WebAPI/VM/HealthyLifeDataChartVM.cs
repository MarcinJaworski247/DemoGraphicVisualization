using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoGraphicVisualization.WebAPI.VM
{
    public class HealthyLifeDataChartVM
    {
        public string Country { get; set; }
        public string Key { get; set; }
        public double ExpectedLife { get; set; }
        public string Year { get; set; }
    }
}
