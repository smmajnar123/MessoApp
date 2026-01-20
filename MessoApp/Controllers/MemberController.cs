using MessoApp.Services.IServices;
using Microsoft.AspNetCore.Mvc;

namespace MessoApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MemberController(IMemberService memberService, ILogger<MemberController> logger) : ControllerBase
    {
        private readonly IMemberService _memberService = memberService;
        private readonly ILogger<MemberController> _logger = logger;

        [HttpGet("allMessMember")]
        public async Task<IActionResult> GetAllMemberProfiles([FromQuery] int messId)
        {
            var result = await _memberService.GetAllMembersByMessIdAsync(messId);
            return Ok(result);
        }
    }
}
