using System.Threading.Tasks;
using FilaSUS.WebAPI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace FilaSUS.WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HospitalsController : ControllerBase
    {
        private readonly ILogger<HospitalsController> _logger;
        private readonly HospitalService _hospitalService;

        public HospitalsController(ILogger<HospitalsController> logger, HospitalService hospitalService)
        {
            _logger = logger;
            _hospitalService = hospitalService;
        }

        [HttpGet("{x:double}:{y:double}/{radius:double}")]
        public async Task<IActionResult> GetHospitalsInRadius(double x, double y, double radius)
        {
            _logger.LogDebug($"x: {x}, y: {y}, radius: {radius}");
            return Ok(await _hospitalService.GetHospitalsInRadius(x, y, radius).ConfigureAwait(false));
        }
    }
}