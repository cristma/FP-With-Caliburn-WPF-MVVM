using AE.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AE.FlightProcedures.Domain.Approaches.Events
{
    internal class ApproachEsaBuilt
    {
        public ApproachEsaBuilt(
            Guid approachId, 
            Guid esaId, 
            CriteriaType criteria)
        {
            this.ApproachId = approachId;
            this.EsaId = esaId;
            this.Criteria = criteria;
        }

        public Guid ApproachId { get; private set; }
        public Guid EsaId { get; private set; }
        public CriteriaType Criteria { get; private set; }
    }
}
