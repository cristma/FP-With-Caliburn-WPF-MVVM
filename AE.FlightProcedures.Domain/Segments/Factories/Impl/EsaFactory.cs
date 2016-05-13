using AE.FlightProcedures.Domain.Approaches;
using AE.FlightProcedures.Domain.Approaches.Factories;
using AE.FlightProcedures.Domain.Construction.Segments.Airspaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AE.FlightProcedures.Domain.Segments.Factories.Impl
{
    internal class EsaFactory : IEsaFactory
    {
        private readonly IConstructFactory constructFactory;
        private readonly ILocationFactory locationFactory;

        public EsaFactory(
            IConstructFactory constructFactory, 
            ILocationFactory locationFactory)
        {
            if (constructFactory == null)
                throw new ArgumentNullException("constructFactory");
            if (locationFactory == null)
                throw new ArgumentNullException("locationFactory");

            this.constructFactory = constructFactory;
            this.locationFactory = locationFactory;
        }

        public Esa CreateEsa(Guid id, double altitude, double radius, double latitude, double longitude)
        {
            Altitude altitudeVo = new Altitude(altitude);
            Radius radiusVo = new Radius(radius);
            Location locationVo = this.locationFactory.CreateLocation(latitude, longitude);
            Construct constructVo = this.constructFactory.CreateEsaConstruct(radiusVo, locationVo);

            return new Esa(id, altitudeVo, radiusVo, locationVo, constructVo, id);
        }
    }
}