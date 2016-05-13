using AE.FlightProcedures.AppServices.Approaches.Impl.Dtos;
using AE.FlightProcedures.AppServices.Segments.Impl.Dtos;
using AE.FlightProcedures.Domain.Approaches;
using System;
using System.Collections.Generic;

namespace AE.FlightProcedures.AppServices.Approaches
{
    public interface IApproachService
    {
        void CreateEsa(EsaSummaryDto dto);
        EsaSummaryDto GetEsa(Guid id);
        IList<Tuple<double, double>> GetConstruct(Guid id);
        bool HasEsa(Guid id);
        void CreateApproach(ApproachDetailsDto dto);
        IReadOnlyList<ApproachSummaryDto> GetApproaches();
        ApproachDetailsDto GetApproach(Guid id);
    }
}
