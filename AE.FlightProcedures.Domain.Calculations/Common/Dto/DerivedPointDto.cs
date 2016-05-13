using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AE.FlightProcedures.Domain.Calculations.Common.Dto
{
    internal class DerivedPointDto
    {
        public DerivedPointDto(
            double latitude, 
            double longitude)
        {
            this.Latitude = latitude;
            this.Longitude = longitude;
        }

        public DerivedPointDto(SuppliedPointDto dto)
        {
            this.Latitude = dto.Latitude;
            this.Longitude = dto.Longitude;
        }

        public double Latitude { get; private set; }
        public double Longitude { get; private set; }
    }
}