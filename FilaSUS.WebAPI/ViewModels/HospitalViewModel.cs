using NetTopologySuite.Geometries;
#pragma warning disable 8618

namespace FilaSUS.WebAPI.ViewModels
{
    public class HospitalViewModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string CNPJ { get; set; }
        public PointViewModel Location { get; set; }
        public long QueueSize { get; set; }
        public double Distance { get; set; }
    }

    public class PointViewModel
    {
        public double X { get; set; }
        public double Y { get; set; }
    }
}