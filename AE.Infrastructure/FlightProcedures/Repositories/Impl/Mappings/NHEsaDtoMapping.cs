using AE.Infrastructure.FlightProcedures.Repositories.Impl.Dtos;
using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AE.Infrastructure.FlightProcedures.Repositories.Impl.Mappings
{
    internal class NHEsaDtoMapping : ClassMap<NHEsaDto>
    {
        public NHEsaDtoMapping()
        {
            Schema("master");
            Table("esas");
            Id(x => x.Id).GeneratedBy.Assigned();
            Map(x => x.Altitude);
            Map(x => x.CenterLatitude);
            Map(x => x.CenterLongitude);
            Map(x => x.Radius);
            Map(x => x.Wkt).CustomSqlType("text");
        }
    }
}
