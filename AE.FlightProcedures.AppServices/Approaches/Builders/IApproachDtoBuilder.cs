using AE.FlightProcedures.AppServices.Approaches.Impl.Dtos;
using AE.FlightProcedures.Domain.Approaches;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AE.FlightProcedures.AppServices.Approaches.Builders
{
    internal interface IApproachDtoBuilder
    {
        ApproachDetailsDto BuildDetailsDto(Approach approach);
        ApproachSummaryDto BuildSummaryDto(Approach approach);
    }
}
