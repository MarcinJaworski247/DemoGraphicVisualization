using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoGraphicVisualization.WebAPI.RestAPI
{
    public interface IRestApiService 
    {
        Task<List<object>> GetTestData();
    }
}
