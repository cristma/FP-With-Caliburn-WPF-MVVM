using AE.Common;
using AE.FlightProcedures.Domain.BoilerPlate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AE.FlightProcedures.Domain.Approaches
{
    internal class Criteria : ValueObject
    {
        public Criteria(CriteriaType criteria)
        {
            if (criteria == CriteriaType.UNDEFINED)
                throw new ArgumentException("criteria");
            this.Value = criteria;
        }

        public CriteriaType Value { get; private set; }
    }
}