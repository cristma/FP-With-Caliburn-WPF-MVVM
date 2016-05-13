using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AE.FlightProcedures.Domain.Approaches
{
    internal class ApproachEsa
    {
        public ApproachEsa(Guid id)
        {
            if (id == Guid.Empty)
                throw new ArgumentException("id");
            this.Id = id;
        }

        public Guid Id { get; private set; }
    }
}