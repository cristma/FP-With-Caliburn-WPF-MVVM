using AE.Common;
using AE.FlightProcedures.AppServices.Approaches;
using AE.FlightProcedures.AppServices.Segments;
using AE.FlightProcedures.Domain.Approaches;
using AE.FlightProcedures.Domain.Evaluation.Deviations;
using AE.FlightProcedures.Domain.Evaluation.Deviations.Factories;
using AE.FlightProcedures.Domain.Evaluation.Observers;
using System;
using System.Collections.Generic;

namespace AE.FlightProcedures.AppServices.Deviations.Impl
{
    internal class DeviationService : IDeviationService
    {
        private readonly IApproachService approachService;
        private readonly IDeviationObserver deviationObserver;
        private readonly IDeviationFactory deviationFactory;

        public DeviationService(
            IApproachService approachService, 
            IDeviationObserver deviationObserver, 
            IDeviationFactory deviationFactory)
        {
            if (approachService == null)
                throw new ArgumentNullException("approachService");
            if (deviationObserver == null)
                throw new ArgumentNullException("deviationObserver");
            if (deviationFactory == null)
                throw new ArgumentNullException("deviationFactory");

            this.approachService = approachService;
            this.deviationObserver = deviationObserver;
            this.deviationFactory = deviationFactory;
        }

        public void EvaluateApproach(Approach approach)
        {
            this.deviationObserver.RemoveDeviation(DeviationMessageConstants.APPR_ESA_REQUIRED_KEY);
            bool hasEsa = this.approachService.HasEsa(approach.Id);

            if(approach.Criteria.Value == CriteriaType.NATO && !hasEsa)
            {
                Deviation deviation = this.deviationFactory.CreateDeviation(
                    DeviationMessageConstants.APPR_ESA_REQUIRED_FOR_NATO, 
                    DeviationMessageConstants.APPR_ESA_REQUIRED_FOR_NATO_SEVERITY);
                deviationObserver.PublishDeviation(DeviationMessageConstants.APPR_ESA_REQUIRED_KEY, deviation);
            }
        }

        public IList<Deviation> GetDeviations()
        {
            return this.deviationObserver.Deviations;
        }
    }
}