using MessoApp.Services.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MessoApp.Controllers
{
    [ApiController]
    [Route("api/v1/member-mess-detail")]
    public class MemberMessDetailController(IMemberMessDetailService memberMessDetailService, ILogger<MemberMessDetailController> logger) : ControllerBase
    {
        private readonly IMemberMessDetailService _memberMessDetailService = memberMessDetailService;
        private readonly ILogger<MemberMessDetailController> _logger = logger;

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] int messId)
        {
            if (messId <= 0)
                return BadRequest("adminId must be greater than zero.");
            var result = await _memberMessDetailService.GetAllAsyn(messId);
            return Ok(result);
        }
    }
}
