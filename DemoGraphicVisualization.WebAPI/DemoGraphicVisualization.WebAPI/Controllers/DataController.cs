using DemoGraphicVisualization.WebAPI.Enums;
using DemoGraphicVisualization.WebAPI.Services;
using DemoGraphicVisualization.WebAPI.VM;
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
        [HttpGet("getPopulationDataToChart/{year}")]
        public ActionResult GetPopulationDataToChart(string year)
        {
            var data = dataService.GetPopulationDataToChart(year);
            return Ok(data);
        }
        [HttpGet("getPopulationDataToMap/{year}")]
        public ActionResult GetPopupulationToMap(string year)
        {
            var data = dataService.GetPopulationDataToMap(year);
            return Ok(data);
        }
        [HttpGet("getPopulationDataToTreeMap/{year}")]
        public ActionResult GetPopulationDataToTreeMap(string year)
        {
            var data = dataService.GetPopulationDataToTreeMap(year);
            return Ok(data);
        }
        [HttpGet("getPopulationDataToGraph/{year}")]
        public ActionResult GetPopulationDataToGraph(string year)
        {
            var data = dataService.GetPopulationDataToGraph(year);
            return Ok(data);
        }
        [HttpPost("getMigrationDataToChart")]
        public ActionResult GetMigrationDataToChart(NationsParamVM param)
        {
            var data = dataService.GetMigrationDataToChart(param.Year, param.SelectedNations);
            return Ok(data);
        }
        [HttpGet("getNationsToLookup")]
        public ActionResult GetNationsToLookup()
        {
            var data = dataService.GetNationsToLookup();
            return Ok(data);
        }
        [HttpGet("getNationMigrationDataToChart/{nation}/{migrationType}")]
        public ActionResult GetNationMigrationDataToChart(string nation, MigrationType migrationType)
        {
            var data = dataService.GetNationMigrationDataToChart(nation, migrationType);
            return Ok(data);
        }
        [HttpGet("getAssaultsDataToChart/{nation}")]
        public ActionResult GetAssaultsDataToChart(string nation)
        {
            var data = dataService.GetAssaultsDataToChart(nation);
            return Ok(data);
        }
        [HttpGet("getHealthyLifeDataToChart/{nation}")]
        public ActionResult GetHealthyLifeDataToChart(string nation)
        {
            var data = dataService.GetHealthyLifeDataToChart(nation);
            return Ok(data);
        }
        [HttpGet("getMigrationAverage/{migrationType}")]
        public ActionResult GetMigrationAverage(MigrationType migrationType)
        {
            var data = dataService.GetMigrationAverage(migrationType);
            return Ok(data);
        }
    }
}   
