using MessoApp.DTO.RequestModels;
using MessoApp.Services.IServices;
using Microsoft.AspNetCore.Mvc;

namespace MessoApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MemberProfileController(IMemberProfileService memberService, ILogger<MemberProfileController> logger) : ControllerBase
    {
        private readonly IMemberProfileService _memberService = memberService;
        private readonly ILogger<MemberProfileController> _logger = logger;

        [HttpGet("AllMemberProfiles")]
        public async Task<IActionResult> GetAllMemberProfiles([FromQuery] int adminId)
        {
            var result = await _memberService.GetAll(adminId);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Post(MemberProfileRequestModel model)
        {
            var result = await _memberService.Add(model);
            return Ok(result);
        }
    }
}
