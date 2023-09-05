using Hangfire.Model.DTOs;
using Hangfire.Model.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Hangfire.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DriversController : ControllerBase
    {
        private readonly ILogger<DriversController> _logger;
        private readonly IDriverService _driverService;
        public DriversController(ILogger<DriversController> logger, IDriverService driverService)
        {
            _logger = logger;
            _driverService = driverService;
        }

        [HttpPost]
        public async Task<IActionResult> Create(DriverDTO model)
        {
            try
            {
                if (model is null)
                    return BadRequest();

                await _driverService.Create(model);

                _logger.LogInformation("Successful processing");

                return Ok(model);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while processing");
                return BadRequest(ex);
            }
        }
    }
}
