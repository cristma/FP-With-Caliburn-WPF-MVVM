using AE.FlightProcedures.AppServices.Segments.Impl.Dtos;
using AE.FlightProcedures.Domain.Segments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AE.FlightProcedures.AppServices.Approaches.Builders.Impl
{
    internal interface IEsaDtoBuilder
    {
        EsaSummaryDto ToDto(Esa model);
    }
}
