using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoGraphicVisualization.WebAPI.Helpers
{
    public class ValueBinder<T1, T2>
    {
        public T1 Key { get; set; }
        public T2 Value { get; set; }
        public ValueBinder()
        {

        }
        public ValueBinder(T1 key, T2 value)
        {
            Key = key;
            Value = value;
        }
    }
}
