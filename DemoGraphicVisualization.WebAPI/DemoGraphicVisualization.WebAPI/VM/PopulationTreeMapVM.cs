using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoGraphicVisualization.WebAPI.VM
{
    public class PopulationTreeMapVM
    {
        public string Name { get; set; }
        public List<PopulationDataTreeMapVM> Items { get; set; }
    }
}
