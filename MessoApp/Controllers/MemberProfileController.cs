using MessoApp.DTO.RequestModels;
using MessoApp.Filters;
using MessoApp.Services.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace MessoApp.Controllers
{
    [ApiController]
    [Route("api/v1/member-profiles/")]
    public class MemberProfileController(IMemberProfileService memberService, ILogger<MemberProfileController> logger) : ControllerBase
    {
        private readonly IMemberProfileService _memberService = memberService;
        private readonly ILogger<MemberProfileController> _logger = logger;


        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Get()
        {
            var adminIdClaim = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (!int.TryParse(adminIdClaim, out int adminId) || adminId <= 0)
            {
                return BadRequest("Invalid or missing adminId.");
            }
            var result = await _memberService.GetAllAsyn(adminId);
            return Ok(result);
        }

        [HttpPost]
        [ServiceFilter(typeof(FluentValidationFilter<MemberProfileRequestModel>))]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Create([FromBody] MemberProfileRequestModel model)
        {
            var result = await _memberService.AddAsyn(model);

            return CreatedAtAction(
                nameof(Get),
                new { adminId = model.AdminId },
                result);
        }

        [HttpPut("{profileId:int}")]
        [ServiceFilter(typeof(FluentValidationFilter<MemberProfileRequestModel>))]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Update(int profileId,[FromBody] MemberProfileRequestModel model)
        {
            if (profileId <= 0)
                return BadRequest("profileId must be greater than zero.");

            var result = await _memberService.UpdateAsyn(profileId, model);
            return Ok(result);
        }

        [HttpGet("profile")]
        [Authorize(Roles = "Member")]
        public async Task<IActionResult> GetMemberProfile()
        {
            var profileIdClaim = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (!int.TryParse(profileIdClaim, out int profileId) || profileId <= 0)
            {
                return BadRequest("Invalid or missing adminId.");
            }
            var result = await _memberService.GetMemberProfileAsyn(profileId);
            return Ok(result);
        }
    }
}
