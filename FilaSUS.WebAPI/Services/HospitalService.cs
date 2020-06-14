using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FilaSUS.WebAPI.Extensions;
using FilaSUS.WebAPI.POCO;
using FilaSUS.WebAPI.Repositories;
using FilaSUS.WebAPI.ViewModels;
using Microsoft.EntityFrameworkCore;
using NetTopologySuite.Geometries;
using Point = NetTopologySuite.Geometries.Point;

namespace FilaSUS.WebAPI.Services
{
    public class HospitalService
    {
        private readonly BaseRepository<Hospital> _hospitalRepository;
        private readonly BaseRepository<Appointment> _appointmentRepository;

        public HospitalService(BaseRepository<Hospital> hospitalRepository, BaseRepository<Appointment> appointmentRepository)
        {
            _hospitalRepository = hospitalRepository;
            _appointmentRepository = appointmentRepository;
        }

        public async Task<IEnumerable<HospitalViewModel>> GetHospitalsInRadius(double x, double y, double radius)
        {
            var point = new Point(x, y) {SRID = 4326};
            var hospitals =
                await _hospitalRepository
                    .GetWithFilter(h => h.Location.Distance(point) <= radius)
                    .ToListAsync();

            return hospitals.Select(h => new HospitalViewModel
            {
                Id = h.Id,
                Name = h.Name,
                CNPJ = h.CNPJ,
                Location = new PointViewModel
                {
                    X = h.Location.X,
                    Y = h.Location.Y
                },
                QueueSize = _appointmentRepository.GetWithFilter(a => a.IdHospital == h.Id && a.EndDate == null).Count(),
                Distance = h.Location.DistanceInMeters(point)
            });
        }
    }
}