using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AE.FlightProcedures.Domain.BoilerPlate
{
    internal class Entity
    {
        public Entity(Guid id)
        {
            if (id == null || id == Guid.Empty)
                throw new ArgumentException("id");

            this.Id = id;
        }

        public Guid Id { get; private set; }
    }
}