
using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using Shared.DataTransferObjects;
using Shared.RequestFeatures;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using Newtonsoft.Json;

namespace Presentation.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UFCFighterController: ControllerBase
    {
        private readonly IServiceManager _service;
        public UFCFighterController(IServiceManager service) { 
            _service=service;
        }
        [HttpGet]
       // [ResponseCache(Duration=60)]
        public IActionResult GetUFCFighters()
        {
            try
            {
                var fighters = _service.FighterService.GetAllUFCFighters();
                return Ok(fighters);
            }
            catch(Exception ex)
            {
                return StatusCode(500, "Internal server error");

            }

        }

        [HttpGet]
        [ActionName("GetFightersPagination")]
        public IActionResult GetUFCFighters([FromQuery]FighterParameters fighterParameter)
        {
            try
            {
                var (fighters, metaData) = _service.FighterService.GetAllUFCFighters(fighterParameter);
                Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(metaData));
                return Ok(fighters);
              
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error");

            }
        }

        [HttpGet]
        public IActionResult DistinctCountries()
        {
            try
            {
                var countries = _service.FighterService.GetDistinctCountries();
                return Ok(countries);

            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error");

            }
        }

        [HttpGet]
        public IActionResult DistinctDivision()
        {
            try
            {
                var countries = _service.FighterService.GetDistinctDivision();
                return Ok(countries);

            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error");

            }
        }


    }
}
