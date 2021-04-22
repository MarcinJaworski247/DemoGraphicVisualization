using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoGraphicVisualization.WebAPI.VM
{
    public class NationMigrationChartDataVM
    {
        public string Year { get; set; }
        public long Migration { get; set; }
        public double? Change { get; set; }
    }
}
