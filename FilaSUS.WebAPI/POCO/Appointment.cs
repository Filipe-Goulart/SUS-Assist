using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FilaSUS.WebAPI.POCO
{
    public class Appointment : Registry
    {
        [ForeignKey("Hospital")] public long IdHospital { get; set; }
        [DataType(DataType.DateTime)] public DateTime StartDate { get; set; }
        [DataType(DataType.DateTime)] public DateTime? EndDate { get; set; }
        public virtual Hospital? Hospital { get; set; }

        public TimeSpan? GetDuration()
        {
            return EndDate?.Subtract(StartDate);
        }
    }
}