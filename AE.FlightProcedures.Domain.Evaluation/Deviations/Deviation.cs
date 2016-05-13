using System;

namespace AE.FlightProcedures.Domain.Evaluation.Deviations
{
    internal class Deviation
    {
        public Deviation(Message message, Severity severity)
        {
            if (message == null)
                throw new ArgumentNullException("message");
            if (severity == null)
                throw new ArgumentNullException("severity");

            this.Message = message;
            this.Severity = severity;
        }

        public Message Message { get; private set; }
        public Severity Severity { get; private set; }
    }
}