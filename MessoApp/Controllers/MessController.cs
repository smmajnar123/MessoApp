
using MessoApp.DTO.RequestModels;
using MessoApp.Filters;
using MessoApp.Services.IServices;
using Microsoft.AspNetCore.Mvc;

namespace MessoApp.Controllers
{
    [ApiController]
    [Route("api/v1/mess")]
    public class MessController(IMessService messService, ILogger<MessController> logger) : ControllerBase
    {
        private readonly IMessService _messService = messService;
        private readonly ILogger<MessController> _logger = logger;

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] int adminId)
        {
            var result = await _messService.GetAllAsyn(adminId);
            return Ok(result);
        }

        [HttpPost]
        [ServiceFilter(typeof(FluentValidationFilter<MessRequestModel>))]
        public async Task<IActionResult> Create([FromBody] MessRequestModel model)
        {
            var result = await _messService.AddAsyn(model);

            return CreatedAtAction(
                nameof(Get),
                new { adminId = model.AdminId },
                result);
        }

        [HttpPut("{messId:int}")]
        [ServiceFilter(typeof(FluentValidationFilter<MessRequestModel>))]
        public async Task<IActionResult> Update(int messId,[FromBody] MessRequestModel model)
        {
            if (messId <= 0)
                return BadRequest("profileId must be greater than zero.");

            var result = await _messService.UpdateAsyn(messId, model);
            return Ok(result);
        }
    }
}
