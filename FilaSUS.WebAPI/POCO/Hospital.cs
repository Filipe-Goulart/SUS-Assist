using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using NetTopologySuite.Geometries;
#pragma warning disable 8618

namespace FilaSUS.WebAPI.POCO
{
    public class Hospital : Registry
    {
        public Hospital() { }

        public Hospital(string name, string cnpj, string address, string zipCode)
        {
            Name = name;
            CNPJ = cnpj;
            Address = address;
            ZipCode = zipCode;
        }

        public string Name { get; set; }

        [RegularExpression(@"/^\d{2}\.\d{3}\.\d{3}\/\d{4}\-\d{2}$/")]
        public string CNPJ { get; set; }

        public string Address { get; set; }
        
        [DataType(DataType.PostalCode)] public string ZipCode { get; set; }
        
        public Point Location { get; set; }
        
        public virtual ICollection<Appointment>? Appointments { get; set; }
    }
}