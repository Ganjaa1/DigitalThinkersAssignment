using DigitalThinkersAssignment.Services;
using Microsoft.AspNetCore.Mvc;

namespace DigitalThinkersAssignment.Controllers
{
    [ApiController]
    public class StockController : ControllerBase
    {
        private IStockService stockService;
        public StockController(IStockService stockService) 
        {
            this.stockService = stockService;
        }

        [HttpPost]
        [Route("/api/v1/Stock")]
        public IActionResult Stock()
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

        [HttpGet]
        [Route("/api/v1/Stock")]
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

        [HttpPost]
        [Route("/api/v1/Checkout")]
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
