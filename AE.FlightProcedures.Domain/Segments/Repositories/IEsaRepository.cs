using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AE.FlightProcedures.Domain.Segments.Repositories
{
    internal interface IEsaRepository
    {
        Esa GetEsa(Guid id);
        void SaveEsa(Esa esa);
    }
}