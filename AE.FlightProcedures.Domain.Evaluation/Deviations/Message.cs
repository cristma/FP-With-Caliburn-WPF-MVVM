using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AE.FlightProcedures.Domain.Evaluation.Deviations
{
    internal class Message
    {
        public Message(string value)
        {
            if (string.IsNullOrEmpty(value))
                throw new ArgumentNullException("value");

            this.Value = value;
        }

        public string Value { get; private set; }
    }
}