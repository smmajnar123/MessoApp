using MessoApp.DTO.RequestModels;
using MessoApp.Filters;
using MessoApp.Services.IServices;
using Microsoft.AspNetCore.Mvc;

namespace MessoApp.Controllers
{
    [ApiController]
    [Route("api/v1/member-profiles")]
    public class MemberProfileController(IMemberProfileService memberService, ILogger<MemberProfileController> logger) : ControllerBase
    {
        private readonly IMemberProfileService _memberService = memberService;
        private readonly ILogger<MemberProfileController> _logger = logger;


        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] int adminId)
        {
            if (adminId <= 0)
                return BadRequest("adminId must be greater than zero.");

            var result = await _memberService.GetAllAsyn(adminId);
            return Ok(result);
        }

        [HttpPost]
        [ServiceFilter(typeof(FluentValidationFilter<MemberProfileRequestModel>))]
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
        public async Task<IActionResult> Update(
            int profileId,
            [FromBody] MemberProfileRequestModel model)
        {
            if (profileId <= 0)
                return BadRequest("profileId must be greater than zero.");

            var result = await _memberService.UpdateAsyn(profileId, model);
            return Ok(result);
        }
    }
}
