using AE.Common;
using System;

namespace AE.FlightProcedures.Domain.Evaluation.Deviations
{
    internal class Severity
    {
        public Severity(DeviationSeverityTypes value)
        {
            if (value == DeviationSeverityTypes.UNDEFINED)
                throw new ArgumentException("value");

            this.Value = value;
        }

        public DeviationSeverityTypes Value { get; private set; }
    }
}