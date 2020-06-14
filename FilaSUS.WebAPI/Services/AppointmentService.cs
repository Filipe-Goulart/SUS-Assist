using System;
using System.Linq;
using System.Threading.Tasks;
using FilaSUS.WebAPI.POCO;
using FilaSUS.WebAPI.Repositories;

namespace FilaSUS.WebAPI.Services
{
    public class AppointmentService
    {
        private readonly BaseRepository<Appointment> _appointmentRepository;

        public AppointmentService(BaseRepository<Appointment> appointmentRepository)
        {
            _appointmentRepository = appointmentRepository;
        }

        public async Task<long> CreateAppointment(long idHospital)
        {
            var appointment = new Appointment
            {
                StartDate = DateTime.Now,
                IdHospital = idHospital
            };
            await _appointmentRepository.InsertAsync(appointment).ConfigureAwait(false);
            return appointment.Id;
        }
        
        public async Task EndAppointment(long idAppointment)
        {
            var appointment = _appointmentRepository.GetWithFilter(a => a.Id == idAppointment).First();
            appointment.EndDate = DateTime.Now;
            await _appointmentRepository.UpdateAsync(appointment).ConfigureAwait(false);
        }
    }
}