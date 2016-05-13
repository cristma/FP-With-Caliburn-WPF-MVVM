using AE.FlightProcedures.Domain.BoilerPlate;
using GeoAPI.Geometries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AE.FlightProcedures.Domain.Segments
{
    internal class Construct : ValueObject
    {
        public Construct(IGeometry geometry)
        {
            if (geometry == null)
                throw new ArgumentNullException("geometry");

            this.Value = geometry;
        }

        public IGeometry Value { get; private set; }
    }
}