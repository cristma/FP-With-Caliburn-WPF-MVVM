using AE.Common;
using System;

namespace AE.FlightProcedures.Domain.Approaches.Factories
{
    internal interface IApproachFactory
    {
        Approach CreateApproach(Guid id, string name, CriteriaType criteria);
    }
}
