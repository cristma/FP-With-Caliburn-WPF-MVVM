using AE.FlightProcedures.Domain.Calculations.Common.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AE.FlightProcedures.Domain.Calculations.Common
{
    internal interface ILocationDerivation
    {
        DerivedPointDto DeriveLocation(SuppliedPointDto startPoint, double bearing, double distance);
    }
}
