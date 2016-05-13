using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AE.FlightProcedures.Domain.BoilerPlate
{
    public class DomainEventPublisher
    {
        private static DomainEventPublisher instance;

        public DomainEventPublisher() { }

        public static DomainEventPublisher Instance()
        {
            if (instance == null)
                instance = new DomainEventPublisher();

            return instance;
        }

        public void Publish(object domainEvent)
        {
            // Do nothing yet.
        }
    }
}