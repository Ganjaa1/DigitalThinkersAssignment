﻿using DigitalThinkersAssignment.Services;
using Microsoft.AspNetCore.Mvc;

namespace DigitalThinkersAssignment.Controllers
{
    [ApiController]
    [Route("api/v1/")]
    public class StockController : ControllerBase
    {
        private IStockService stockService;
        public StockController(IStockService stockService) 
        {
            this.stockService = stockService;
        }

        [HttpPost("Stock")]
        public IActionResult UpdateStock([FromBody] Dictionary<string, int> currencies)
        {
            try
            {
                stockService.UpdateStock(currencies);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("Stock")]
        public IActionResult GetCurrentStock() 
        {
            try
            {
                return Ok(this.stockService.GetCurrentStock());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("Checkout")]
        public IActionResult Checkout()
        {
            try
            {
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}