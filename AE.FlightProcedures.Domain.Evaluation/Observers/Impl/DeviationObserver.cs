using AE.FlightProcedures.Domain.Evaluation.Deviations;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AE.FlightProcedures.Domain.Evaluation.Observers.Impl
{
    internal class DeviationObserver : IDeviationObserver
    {
        private readonly IDictionary<string, Deviation> deviationCache;

        public DeviationObserver()
        {
            this.deviationCache = new Dictionary<string, Deviation>();
        }

        public IList<Deviation> Deviations { get { return this.deviationCache.Values.ToList(); } }

        public void PublishDeviation(string key, Deviation deviation)
        {
            if(!this.deviationCache.ContainsKey(key))
                this.deviationCache.Add(key, deviation);
        }

        public void RemoveDeviation(string key)
        {
            if(this.deviationCache.ContainsKey(key))
            {
                this.deviationCache.Remove(key);
            }
        }

        public void ClearDeviations()
        {
            this.deviationCache.Clear();
        }
    }
}