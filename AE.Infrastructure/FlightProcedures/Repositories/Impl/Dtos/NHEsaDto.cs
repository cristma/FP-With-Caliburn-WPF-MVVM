using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AE.Infrastructure.FlightProcedures.Repositories.Impl.Dtos
{
    internal class NHEsaDto
    {
        public NHEsaDto()
        {
        }

        public virtual Guid Id { get; set; }
        public virtual double Altitude { get; set; }
        public virtual double Radius { get; set; }
        public virtual double CenterLatitude { get; set; }
        public virtual double CenterLongitude { get; set; }
        public virtual string Wkt { get; set; }
    }
}