using AE.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AE.FlightProcedures.AppServices.Approaches.Impl.Dtos
{
    public class ApproachDetailsDto
    {
        public ApproachDetailsDto(
            Guid id, 
            string name, 
            CriteriaType criteria)
        {
            this.Id = id;
            this.Name = name;
            this.Criteria = criteria;
        }

        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public CriteriaType Criteria { get; private set; }
    }
}
