using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHM.Models
{
    [Flags]
    public enum BrewKind
    {
        None = 0,
        PSV = 1,
        PS3 = 2,
        PS4 = 4,
        All = ~0
    }
}
