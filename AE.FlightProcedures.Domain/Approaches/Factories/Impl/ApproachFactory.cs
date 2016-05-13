using AE.Common;
using System;

namespace AE.FlightProcedures.Domain.Approaches.Factories.Impl
{
    internal class ApproachFactory : IApproachFactory
    {
        public Approach CreateApproach(Guid id, string name, CriteriaType criteria)
        {
            Name nameVo = new Name(name);
            Criteria criteriaVo = new Criteria(criteria);
            Approach approach = new Approach(id, nameVo, criteriaVo);

            return approach;
        }
    }
}