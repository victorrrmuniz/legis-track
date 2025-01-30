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
        [Route("legislator/{legislatorId}")]
        public IActionResult GetLegislatorBillSupportStats(long legislatorId)
        {
            var result = _billService.GetLegislatorBillStatis(legislatorId);

            return Ok(result);
        }

        [HttpGet]
        [Route("bill/{billId}")]
        public IActionResult GetBillSupportStats(long billId)
        {
            var result = _billService.GetBillSupportStats(billId);

            return Ok(result);
        }
    }
}
