using AE.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AE.FlightProcedures.AppServices.Deviations.Impl.Dtos
{
    public class DeviationSummaryDto
    {
        public DeviationSummaryDto(string message, DeviationSeverityTypes severity)
        {
            this.Message = message;
            this.Severity = severity;
        }

        public string Message { get; private set; }
        public DeviationSeverityTypes Severity { get; private set; }
    }
}