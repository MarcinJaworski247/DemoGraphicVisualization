using DemoGraphicVisualization.WebAPI.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoGraphicVisualization.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DataController : ControllerBase
    {
        private readonly IDataService dataService;
        public DataController(IDataService dataService)
        {
            this.dataService = dataService;
        }
        [HttpGet("getPopulationData")]
        public ActionResult GetPopulationData()
        {
            var data = dataService.GetPopulationData();
            return Ok(data);
        }
    }
}   
