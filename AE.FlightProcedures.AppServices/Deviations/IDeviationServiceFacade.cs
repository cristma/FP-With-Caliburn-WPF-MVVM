using AE.FlightProcedures.AppServices.Deviations.Impl.Dtos;
using System.Collections.Generic;

namespace AE.FlightProcedures.AppServices.Deviations
{
    public interface IDeviationServiceFacade
    {
        IList<DeviationSummaryDto> GetDeviations();
    }
}