using LegisTrack.Services;
using Microsoft.AspNetCore.Mvc;

namespace LegisTrack.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BillController : ControllerBase
    {

        private readonly IBillService _billService;

        public BillController(IBillService billService)
        {
            _billService = billService;
        }

        [HttpGet]
        [Route("legislator-stats")]
        public IActionResult GetLegislatorBillSupportStats()
        {
            var result = _billService.GetLegislatorBillStats();

            return Ok(result);
        }

        [HttpGet]
        [Route("bill-stats")]
        public IActionResult GetBillSupportStats()
        {
            var result = _billService.GetBillSupportStats();

            return Ok(result);
        }
    }
}
