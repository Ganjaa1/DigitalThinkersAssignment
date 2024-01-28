using Microsoft.AspNetCore.Mvc;

namespace DigitalThinkersAssignment.Controllers
{
    [ApiController]
    public class StockController : ControllerBase
    {

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
                return Ok();
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
