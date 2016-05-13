using AE.FlightProcedures.Domain.Calculations.Common.Dto;
using Geodesy;
using System;
using System.Collections.Generic;

namespace AE.FlightProcedures.Domain.Calculations.Common.Impl
{
    internal class ArcDerivation : IArcDerivation
    {
        private readonly GeodeticCalculator calculator;

        public ArcDerivation()
        {
            this.calculator = new GeodeticCalculator(Ellipsoid.WGS84);
        }

        public IList<DerivedPointDto> CreateArc(double radius, SuppliedPointDto centerPoint, SuppliedPointDto startPoint, SuppliedPointDto endPoint)
        {
            Angle centerLatitude = new Angle(centerPoint.Latitude);
            Angle centerLongitude = new Angle(centerPoint.Longitude);
            Angle startLatitude = new Angle(startPoint.Latitude);
            Angle startLongitude = new Angle(startPoint.Longitude);
            Angle endLatitude = new Angle(endPoint.Latitude);
            Angle endLongitude = new Angle(endPoint.Longitude);

            GlobalCoordinates centerCoordinate = new GlobalCoordinates(centerLatitude, centerLongitude);
            GlobalCoordinates startCoordinate = new GlobalCoordinates(startLatitude, startLongitude);
            GlobalCoordinates endCoordinate = new GlobalCoordinates(endLatitude, endLongitude);
           
            GlobalPosition centerPosition = new GlobalPosition(centerCoordinate);
            GlobalPosition startPosition = new GlobalPosition(startCoordinate);
            GlobalPosition endPosition = new GlobalPosition(endCoordinate);

            GeodeticMeasurement centerToStartMeasurement = calculator.CalculateGeodeticMeasurement(centerPosition, startPosition);
            GeodeticMeasurement centerToEndMeasurement = calculator.CalculateGeodeticMeasurement(centerPosition, endPosition);

            // Radius should ensure that it is tolerable (we are going to ingore it in this implementation)
            double startDistance = centerToStartMeasurement.PointToPointDistance;
            double endDistance = centerToEndMeasurement.PointToPointDistance;
            double distanceDelta = Math.Abs(startDistance - endDistance);
            double distanceEpsilon = distanceDelta / 10;            

            Angle startBearing = centerToStartMeasurement.Azimuth;
            Angle endBearing = centerToEndMeasurement.Azimuth;

            double degreesDelta = Math.Abs(startBearing.Degrees - endBearing.Degrees);
            double degreesEpsilon = degreesDelta / 10;  // Our angular distribution

            IList<DerivedPointDto> arcPoints = new List<DerivedPointDto>();

            // We are going to assume that arc derivation is done in a clockwise position.
            for (int i = 0; i < 10; i++) // Such that the 10th increment should equate to the end point and the initial the start
            {
                Angle nextBearing = new Angle(startBearing.Degrees + (degreesEpsilon * (i + 1)));
                GlobalCoordinates thetaLocation = calculator.CalculateEndingGlobalCoordinates(centerCoordinate, nextBearing, startDistance + (distanceEpsilon * (i + 1)));
                DerivedPointDto thetaPoint = new DerivedPointDto(thetaLocation.Latitude.Degrees, thetaLocation.Longitude.Degrees);

                arcPoints.Add(thetaPoint);
            }

            return arcPoints;
        }

        public IList<DerivedPointDto> CreateArc(double radius, SuppliedPointDto centerPoint, double startBearing, double endBearing)
        {
            throw new NotImplementedException();
        }
    }
}
