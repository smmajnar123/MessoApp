
using MessoApp.Services.IServices;
using Microsoft.AspNetCore.Mvc;

namespace MessoApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessController(IMessService messService, ILogger<MessController> logger) : ControllerBase
    {
        private readonly IMessService _messService = messService;
        private readonly ILogger<MessController> _logger = logger;

        [HttpGet("allMessess")]
        public async Task<IActionResult> GetAllMessess([FromQuery] int adminId)
        {
            var result = await _messService.GetAllMessByAdminIdAsync(adminId);
            return Ok(result);
        }
    }
}
