using AE.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AE.Infrastructure.FlightProcedures.Repositories.Impl.Dtos
{
    internal class NHApproachDto
    {
        public NHApproachDto()
        {
        }

        public virtual Guid Id { get; set; }
        public virtual string Name { get; set; }
        public virtual CriteriaType Criteria { get; set; }
        public virtual Guid? EsaId { get; set; }
    }
}