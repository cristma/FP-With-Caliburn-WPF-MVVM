using AE.FlightProcedures.Domain.BoilerPlate;
using System;

namespace AE.FlightProcedures.Domain.Segments
{
    internal class Latitude : ValueObject
    {
        public Latitude(double value)
        {
            if (double.IsNaN(value) || value > 90 || value < -90)
                throw new ArgumentException("value");

            this.Value = value;
        }

        public double Value { get; private set; }
    }
}