using DigitalThinkersAssignment.Exceptions;
using DigitalThinkersAssignment.Models;
using DigitalThinkersAssignment.Services;
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
            if (currencies == null) return BadRequest("Invalid stock update request. Please provide a valid request.");

            try
            {
                return Ok(stockService.UpdateStock(currencies));
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
        public IActionResult Checkout([FromBody] CheckoutData checkoutData)
        {
            try
            {
                return Ok(this.stockService.Checkout(checkoutData));
            }
            catch (StockException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
