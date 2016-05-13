using AE.Common;
using AE.FlightProcedures.AppServices.Deviations.Impl.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AE.Presentation.ViewModels.Deviations
{
    public interface IDeviationSummaryViewModel
    {
        string Message { get; }
        DeviationSeverityTypes Severity { get; }

        void Load(DeviationSummaryDto dto);
    }
}