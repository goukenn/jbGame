using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JamboGame
{
    /// <summary>
    /// represent a player Type
    /// </summary>
    [Flags()]
    public enum enuJGPlayerType
    {
        Unknow = 0x0,
        Player = 0x1,
        Computer=0x2,
        Visitor = 0x4,
        PlayerVisitor = Player | Visitor 
    }
}
