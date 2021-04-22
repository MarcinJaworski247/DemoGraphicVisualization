using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoGraphicVisualization.WebAPI.VM
{
    public class MigrationDataChartVM
    {
        public string Nation { get; set; }
        public long Immigration { get; set; }
        public long Emigration { get; set; }
    }
}
