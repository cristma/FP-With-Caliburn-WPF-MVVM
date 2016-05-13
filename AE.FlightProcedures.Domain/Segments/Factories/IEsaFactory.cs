using AE.FlightProcedures.Domain.Approaches;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AE.FlightProcedures.Domain.Segments.Factories
{
    internal interface IEsaFactory
    {
        Esa CreateEsa(Guid id, double altitude, double radius, double latitude, double longitude);
    }
}
