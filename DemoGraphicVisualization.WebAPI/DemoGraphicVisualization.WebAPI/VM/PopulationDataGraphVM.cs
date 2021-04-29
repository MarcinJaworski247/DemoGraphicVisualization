using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoGraphicVisualization.WebAPI.VM
{
    public class GraphNodeVM
    {
        public GraphNodeVM()
        {
            Group = 1;
        }
        public string Id { get; set; }
        public int Group { get; set; }
    }
    public class GraphLinkVM
    {
        public GraphLinkVM()
        {
            Source = "base";
        }
        public string Source { get; set; }
        public string Target { get; set; }
        public long? Population { get; set; }
        public double Value { get; set; }
    }
    public class PopulationDataGraphVM
    {
        public PopulationDataGraphVM()
        {
            Nodes = new List<GraphNodeVM>
            {
                new GraphNodeVM
                {
                    Id = "base"
                }
            };
            Links = new List<GraphLinkVM>();
        }
        public List<GraphNodeVM> Nodes { get; set; }
        public List<GraphLinkVM> Links { get; set; }
    }
}
