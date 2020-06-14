using System.Collections.Generic;
using FilaSUS.WebAPI.POCO;
using Microsoft.EntityFrameworkCore;
using NetTopologySuite.Geometries;
#pragma warning disable 8618

namespace FilaSUS.WebAPI.Data
{
    public class SUSContext : DbContext
    {
        public SUSContext() { }

        public SUSContext(DbContextOptions options) : base(options) { }

        public DbSet<Hospital> Hospitals { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Appointment>(e =>
            {
                e.HasOne(a => a.Hospital)
                    .WithMany(h => h!.Appointments)
                    .HasForeignKey(a => a.IdHospital)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<Hospital>(e =>
            {
                e.HasData(new List<Hospital>
                {
                    new Hospital
                    {
                        Id = 1,
                        Name = "Hospital Municipal Salgado Filho",
                        Address = "R. Arquias Cordeiro, 370 - Méier, Rio de Janeiro - RJ",
                        ZipCode = "20770-000",
                        Location = new Point(new Coordinate(-22.9008899, -43.2803995))
                        {
                            SRID = 4326
                        },
                        CNPJ = "29.468.055/0004-55"
                    }
                });
            });
        }
    }
}