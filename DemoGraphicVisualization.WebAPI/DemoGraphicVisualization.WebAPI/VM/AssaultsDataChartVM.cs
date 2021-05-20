using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoGraphicVisualization.WebAPI.VM
{
    public class AssaultsDataChartVM
    {
        public string Country { get; set; }
        public string Key { get; set; }
        public double? Assaults { get; set; }
        public string Year { get; set; }
    }
}
