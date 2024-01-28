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
        public IActionResult Checkout([FromBody] CheckoutData checkoutData)
        {
            if (checkoutData == null) return BadRequest("Invalid purchase request. Please provide a valid request.");
            
            if (checkoutData.Price <= 0 || checkoutData.Price <= 0) return BadRequest("The price entered must be a number or a non-negative number!");
            
            int totalInserted = checkoutData.Inserted.Sum(kvp => Convert.ToInt32(kvp.Key) * kvp.Value);
            if (totalInserted < checkoutData.Price) return BadRequest("The cash given does not cover the price!");

            try
            {
                return Ok(this.stockService.Checkout(checkoutData,totalInserted));
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
