using AE.FlightProcedures.AppServices.Deviations.Impl.Dtos;
using AE.FlightProcedures.Domain.Evaluation.Deviations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AE.FlightProcedures.AppServices.Deviations.Builders
{
    internal interface IDeviationDtoBuilder
    {
        DeviationSummaryDto ToDto(Deviation deviation);
    }
}
