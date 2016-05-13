using AE.FlightProcedures.Domain.Calculations.Common;
using AE.FlightProcedures.Domain.Calculations.Common.Dto;
using GeoAPI.Geometries;
using NetTopologySuite.Geometries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AE.FlightProcedures.Domain.Construction.Segments.Airspaces.Impl
{
    internal class EsaConstructBuilder : IEsaConstructBuilder
    {
        private readonly IArcDerivation arcDerivation;
        private readonly ILocationDerivation locationDerivation;

        public EsaConstructBuilder(
            IArcDerivation arcDerivation, 
            ILocationDerivation locationDerivation)
        {
            if (arcDerivation == null)
                throw new ArgumentNullException("arcDerivation");
            if (locationDerivation == null)
                throw new ArgumentNullException("locationDerivation");

            this.arcDerivation = arcDerivation;
            this.locationDerivation = locationDerivation;
        }

        public IGeometry BuildEsa(double radius, double latitude, double longitude)
        {
            SuppliedPointDto centerPoint = new SuppliedPointDto(latitude, longitude);
            DerivedPointDto startPointDerived = this.locationDerivation.DeriveLocation(centerPoint, 0, radius);
            DerivedPointDto endPointDerived = this.locationDerivation.DeriveLocation(centerPoint, 180, radius);
            SuppliedPointDto startPoint = new SuppliedPointDto(startPointDerived);
            SuppliedPointDto endPoint = new SuppliedPointDto(endPointDerived);


            IList<DerivedPointDto> derivedRightArc = this.arcDerivation.CreateArc(radius, centerPoint, startPoint, endPoint);
            IList<DerivedPointDto> derivedLeftArc = this.arcDerivation.CreateArc(radius, centerPoint, endPoint, startPoint);
            IList<DerivedPointDto> derivedCircle = derivedRightArc.Concat(derivedLeftArc).ToList();
            derivedCircle.Add(derivedCircle.First());   // Force closure

            IList<Coordinate> coordinates = new List<Coordinate>();

            foreach(DerivedPointDto point in derivedCircle)
            {
                coordinates.Add(new Coordinate(point.Longitude, point.Latitude));
            }

            return new Polygon(new LinearRing(coordinates.ToArray()));
        }
    }
}
