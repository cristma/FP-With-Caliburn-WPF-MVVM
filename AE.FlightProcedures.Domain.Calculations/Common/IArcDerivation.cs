using AE.FlightProcedures.Domain.Calculations.Common.Dto;
using System.Collections.Generic;

namespace AE.FlightProcedures.Domain.Calculations.Common
{
    internal interface IArcDerivation
    {
        IList<DerivedPointDto> CreateArc(double radius, SuppliedPointDto centerPoint, SuppliedPointDto startPoint, SuppliedPointDto endPoint);
        IList<DerivedPointDto> CreateArc(double radius, SuppliedPointDto centerPoint, double startBearing, double endBearing);
    }
}