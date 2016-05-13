using AE.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AE.Common
{
    public class DeviationMessageConstants
    {
        public const string APPR_ESA_REQUIRED_KEY = "APPR_ESA_REQUIRED_FOR_NATO";
        public const string APPR_ESA_REQUIRED_FOR_NATO = "Approaches that are using NATO criteria require an ESA.";
        public const DeviationSeverityTypes APPR_ESA_REQUIRED_FOR_NATO_SEVERITY = DeviationSeverityTypes.WARNING;
    }
}
