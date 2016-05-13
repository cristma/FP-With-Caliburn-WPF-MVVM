using AE.Common;
using AE.FlightProcedures.Domain.Approaches.Events;
using AE.FlightProcedures.Domain.BoilerPlate;
using AE.FlightProcedures.Domain.Evaluation.Deviations;
using AE.FlightProcedures.Domain.Evaluation.Deviations.Factories;
using AE.FlightProcedures.Domain.Evaluation.Observers;
using AE.FlightProcedures.Domain.Segments;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AE.FlightProcedures.Domain.Approaches
{
    internal class Approach : Entity
    {
        public Approach(
            Guid id, 
            Name name, 
            Criteria criteria)
            : base(id)
        {
            Contract.Assert(name != null, "Name cannot be null for an approach.");
            Contract.Assert(criteria != null, "Criteria cannot be null for an approach.");

            this.Name = name;
            this.Criteria = criteria;

            DomainEventPublisher.Instance().Publish(
                new ApproachCreated(
                    id, 
                    name.Value, 
                    criteria.Value));
        }

        public Name Name { get; private set; }
        public Criteria Criteria { get; private set; }
        public ApproachEsa Esa { get; private set; }
        public bool HasEsa { get { return this.Esa != null; } }

        public Esa BuildEsa(
            Altitude altitude, 
            Radius radius, 
            Location location, 
            Construct construct)
        {
            Esa esa = new Esa(this.Id, altitude, radius, location, construct, this.Id);
            DomainEventPublisher.Instance().Publish(
                new ApproachEsaBuilt(
                    this.Id, 
                    esa.Id,
                    this.Criteria.Value));

            return esa;
        }

        public void AddEsa(Esa esa)
        {
            Contract.Assert(esa.Id == this.Id, "The identifier for the ESA must be the same as the approach.");
            Contract.Assert(this.Criteria.Value == CriteriaType.NATO, "ESA's may only be added to NATO approaches.");

            ApproachEsa esaValue = new ApproachEsa(esa.Id);
            this.Esa = esaValue;
        }

        // Requires the double delegate method to process a domain service (per Vaughn Vernon).
        public void Evaluate( 
            IDeviationObserver deviationObserver, 
            IDeviationFactory deviationFactory)
        {
            if (this.Criteria.Value == CriteriaType.NATO)
            {
                bool result = this.Esa == null;

                if (result)
                {
                    Deviation deviation = deviationFactory.CreateDeviation(
                        DeviationMessageConstants.APPR_ESA_REQUIRED_FOR_NATO,
                        DeviationMessageConstants.APPR_ESA_REQUIRED_FOR_NATO_SEVERITY);
                    deviationObserver.PublishDeviation(DeviationMessageConstants.APPR_ESA_REQUIRED_KEY, deviation);
                }
            }
        }
    }
}