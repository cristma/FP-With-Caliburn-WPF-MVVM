using AE.FlightProcedures.Domain.Calculations.Common.Dto;
using Geodesy;

namespace AE.FlightProcedures.Domain.Calculations.Common.Impl
{
    internal class LocationDerivation : ILocationDerivation
    {
        private readonly GeodeticCalculator calculator;

        public LocationDerivation()
        {
            this.calculator = new GeodeticCalculator(Ellipsoid.WGS84);
        }

        public DerivedPointDto DeriveLocation(SuppliedPointDto startPoint, double bearing, double distance)
        {
            Angle azimuth = new Angle(bearing);
            Angle startLatitude = new Angle(startPoint.Latitude);
            Angle startLongitude = new Angle(startPoint.Longitude);
            GlobalCoordinates startCoordinate = new GlobalCoordinates(startLatitude, startLongitude);
            GlobalCoordinates endCoordinate = this.calculator.CalculateEndingGlobalCoordinates(startCoordinate, azimuth, distance);
            DerivedPointDto derived = new DerivedPointDto(endCoordinate.Latitude.Degrees, endCoordinate.Longitude.Degrees);

            return derived;
        }
    }
}