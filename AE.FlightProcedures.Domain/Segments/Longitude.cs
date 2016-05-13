using AE.FlightProcedures.Domain.BoilerPlate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AE.FlightProcedures.Domain.Segments
{
    internal class Longitude : ValueObject
    {
        public Longitude(double value)
        {
            if (double.IsNaN(value) || value > 180 || value < -180)
                throw new ArgumentException("value");

            this.Value = value;
        }

        public double Value { get; private set; }
    }
}
