using MessoApp.Services.IServices;
using Microsoft.AspNetCore.Authorization;
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

        [HttpGet("{profileId:int}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Get(int profileId)
        {
            if (profileId <= 0)
                return BadRequest("adminId must be greater than zero.");
            var result = await _memberMessDetailService.GetMemberMessDetailsAsync(profileId);
            return Ok(result);
        }
    }
}
