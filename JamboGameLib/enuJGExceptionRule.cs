using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JamboGame
{
    [Flags ()]
    public enum enuJGExceptionRule
    {
        None = 0,
        Threeseven = 0x01,
        FourSeven = 0x02,
        TwentyOneRule = 0x04,
    }
}
