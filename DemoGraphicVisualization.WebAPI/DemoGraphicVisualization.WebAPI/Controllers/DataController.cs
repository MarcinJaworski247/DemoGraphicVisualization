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
        [HttpGet("getTestData")]
        public ActionResult GetTestData()
        {
            var data = dataService.GetTestData();
            return Ok(data);
        }
    }
}   
