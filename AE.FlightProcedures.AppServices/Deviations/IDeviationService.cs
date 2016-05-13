using AE.FlightProcedures.Domain.Approaches;
using AE.FlightProcedures.Domain.Evaluation.Deviations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AE.FlightProcedures.AppServices.Deviations
{
    internal interface IDeviationService
    {
        void EvaluateApproach(Approach approach);
        IList<Deviation> GetDeviations();
    }
}
