using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AE.FlightProcedures.Domain.Segments.Factories
{
    internal interface ILocationFactory
    {
        Location CreateLocation(double latitude, double longitude);
    }
}