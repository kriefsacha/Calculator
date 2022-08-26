using CalculatorAPI.Interfaces;
using CalculatorAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CalculatorAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CalculationController : ControllerBase
    {
        private readonly ICalculationService calculationService;
        public CalculationController(ICalculationService calculationService)
        {
            this.calculationService = calculationService;
        }

        [HttpPost("calculate")]
        public IActionResult Calculate([FromBody]CalculateModel model)
        {
            try
            {
                var res = calculationService.Calculate(model.Expression);
                return Ok(res);

            }
            catch (Exception e)
            {
                return BadRequest(e.Message + " " + e.StackTrace);
            }
        }
    }
}
