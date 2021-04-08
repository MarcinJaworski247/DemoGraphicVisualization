using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoGraphicVisualization.WebAPI.Helpers
{
    public class Colors
    {
        public string GetRandomHTMLColor()
        {
            var random = new Random();
            return String.Format("#{0:X6}", random.Next(0x1000000));
        }
    }
}
