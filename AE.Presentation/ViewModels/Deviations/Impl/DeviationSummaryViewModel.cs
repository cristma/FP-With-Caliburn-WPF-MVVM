using AE.Common;
using AE.FlightProcedures.AppServices.Deviations.Impl.Dtos;

namespace AE.Presentation.ViewModels.Deviations.Impl
{
    public class DeviationSummaryViewModel : IDeviationSummaryViewModel
    {
        public string Message { get; private set; }
        public DeviationSeverityTypes Severity { get; private set; }

        public void Load(DeviationSummaryDto dto)
        {
            this.Message = dto.Message;
            this.Severity = dto.Severity;
        }
    }
}