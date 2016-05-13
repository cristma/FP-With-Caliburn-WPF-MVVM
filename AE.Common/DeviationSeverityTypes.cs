using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AE.Common
{
    public enum DeviationSeverityTypes
    {
        UNDEFINED = -1, 
        NOTE = 0, 
        WARNING = 1, 
        WAIVER = 2, 
        SIZE_OF = WAIVER + 1
    }
}
