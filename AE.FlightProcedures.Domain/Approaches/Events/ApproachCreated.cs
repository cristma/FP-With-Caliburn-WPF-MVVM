using AE.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AE.FlightProcedures.Domain.Approaches.Events
{
    internal class ApproachCreated
    {
        public ApproachCreated(
            Guid approachId, 
            string name, 
            CriteriaType criteria)
        {
            this.ApproachId = approachId;
            this.Name = name;
            this.Criteria = criteria;
        }

        public Guid ApproachId { get; private set; }
        public string Name { get; private set; }
        public CriteriaType Criteria { get; private set; }
    }
}