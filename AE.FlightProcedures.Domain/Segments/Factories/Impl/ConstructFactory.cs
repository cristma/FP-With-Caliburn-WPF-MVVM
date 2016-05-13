using AE.FlightProcedures.Domain.Construction.Segments.Airspaces;
using GeoAPI.Geometries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AE.FlightProcedures.Domain.Segments.Factories.Impl
{
    internal class ConstructFactory : IConstructFactory
    {
        private readonly IEsaConstructBuilder esaBuilder;

        public ConstructFactory(
            IEsaConstructBuilder esaBuilder)
        {
            if (esaBuilder == null)
                throw new ArgumentNullException("esaBuilder");

            this.esaBuilder = esaBuilder;
        }

        public Construct CreateEsaConstruct(Radius radius, Location location)
        {
            if (radius == null)
                throw new ArgumentNullException("radius");
            if (location == null)
                throw new ArgumentNullException("location");

            IGeometry geometry = this.esaBuilder.BuildEsa(radius.Value, location.Latitude.Value, location.Longitude.Value);

            return new Construct(geometry);
        }
    }
}