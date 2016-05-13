using AE.FlightProcedures.Domain.Evaluation.Deviations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AE.FlightProcedures.Domain.Evaluation.Observers
{
    internal interface IDeviationObserver
    {
        IList<Deviation> Deviations { get; }
        void PublishDeviation(string key, Deviation deviation);
        void RemoveDeviation(string key);
        void ClearDeviations();
    }
}
