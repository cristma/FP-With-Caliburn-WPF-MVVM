using AE.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AE.FlightProcedures.Domain.Evaluation.Deviations.Factories.Impl
{
    internal class DeviationFactory : IDeviationFactory
    {
        public Deviation CreateDeviation(string message, DeviationSeverityTypes severity)
        {
            Message messageVo = new Message(message);
            Severity severityVo = new Severity(severity);
            Deviation deviation = new Deviation(messageVo, severityVo);

            return deviation;
        }
    }
}