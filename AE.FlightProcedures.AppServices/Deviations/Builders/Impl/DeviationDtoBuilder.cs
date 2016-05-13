using AE.FlightProcedures.AppServices.Deviations.Impl.Dtos;
using AE.FlightProcedures.Domain.Evaluation.Deviations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AE.FlightProcedures.AppServices.Deviations.Builders.Impl
{
    internal class DeviationDtoBuilder : IDeviationDtoBuilder
    {
        public DeviationSummaryDto ToDto(Deviation deviation)
        {
            DeviationSummaryDto dto = new DeviationSummaryDto(deviation.Message.Value, deviation.Severity.Value);
            return dto;
        }
    }
}