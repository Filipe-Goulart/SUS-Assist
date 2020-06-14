using System.Threading.Tasks;
using FilaSUS.WebAPI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace FilaSUS.WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AppointmentsController : ControllerBase
    {
        private readonly ILogger<HospitalsController> _logger;
        private readonly AppointmentService _appointmentService;

        public AppointmentsController(ILogger<HospitalsController> logger, AppointmentService appointmentService)
        {
            _logger = logger;
            _appointmentService = appointmentService;
        }

        [HttpPost("{idHospital:long}")]
        public async Task<IActionResult> PostAppointment(long idHospital)
        {
            return Ok(await _appointmentService.CreateAppointment(idHospital).ConfigureAwait(false));
        }
        
        [HttpPut("{idAppointment:long}")]
        public async Task<IActionResult> PutAppointment(long idAppointment)
        {
            await _appointmentService.EndAppointment(idAppointment).ConfigureAwait(false);
            return Ok();
        }
    }
}