using AE.FlightProcedures.AppServices.Approaches.Impl.Dtos;
using AE.FlightProcedures.Domain.Approaches;
using System;

namespace AE.FlightProcedures.AppServices.Approaches.Builders.Impl
{
    internal class ApproachDtoBuilder : IApproachDtoBuilder
    {
        public ApproachDetailsDto BuildDetailsDto(Approach approach)
        {
            if (approach == null)
                throw new ArgumentNullException("approach");

            return new ApproachDetailsDto(approach.Id, approach.Name.Value, approach.Criteria.Value);
        }

        public ApproachSummaryDto BuildSummaryDto(Approach approach)
        {
            if (approach == null)
                throw new ArgumentNullException("approach");

            return new ApproachSummaryDto(approach.Id, approach.Name.Value, approach.Criteria.Value);
        }
    }
}
