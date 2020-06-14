using System;
using NetTopologySuite.Geometries;

namespace FilaSUS.WebAPI.Extensions
{
    public static class PointExtensions
    {
        private const long EarthRadius = 6371000;
        public static double DistanceInMeters(this Point point1, Point point2)
        {
            var rtheta1 = point1.X * Math.PI / 180;
            var rtheta2 = point2.X * Math.PI / 180;
            var dtheta = (rtheta2-rtheta1) * Math.PI/180;
            var dlambda = (point2.Y-point1.Y) * Math.PI/180;
            var a = Math.Sin(dtheta/2) * Math.Sin(dtheta/2) +
                           Math.Cos(rtheta1) * Math.Cos(rtheta2) *
                           Math.Sin(dlambda/2) * Math.Sin(dlambda/2);
            
            var c = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1-a));
            
            return EarthRadius * c;
        }
    }
}