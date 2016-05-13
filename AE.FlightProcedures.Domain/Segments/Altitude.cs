using AE.FlightProcedures.Domain.BoilerPlate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AE.FlightProcedures.Domain.Segments
{
    internal class Altitude : ValueObject
    {
        public Altitude(double value)
        {
            if (value == double.NaN || double.IsInfinity(value))
                throw new ArgumentException("value");

            this.Value = value;
        }

        public double Value { get; private set; }
    }
}
