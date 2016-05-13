using AE.Infrastructure.FlightProcedures.Repositories.Impl.Dtos;
using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AE.Infrastructure.FlightProcedures.Repositories.Impl.Mappings
{
    internal class NHApproachDtoMapping : ClassMap<NHApproachDto>
    {
        public NHApproachDtoMapping()
        {
            Schema("master");
            Table("approaches");
            Id(x => x.Id).GeneratedBy.Assigned();
            Map(x => x.Name);
            Map(x => x.Criteria);
            Map(x => x.EsaId);
        }
    }
}
