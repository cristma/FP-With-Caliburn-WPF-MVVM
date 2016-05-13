using System;
using System.Collections.Generic;

namespace AE.FlightProcedures.Domain.Approaches.Repositories
{
    internal interface IApproachRepository
    {
        void Save(Approach approach);
        IList<Approach> GetApproaches();
        Approach GetApproach(Guid id);
    }
}