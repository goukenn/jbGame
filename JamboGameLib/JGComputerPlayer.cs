using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JamboGame
{
    /// <summary>
    /// reprensent a computer player
    /// </summary>
    public class JGComputerPlayer : JGPlayer 
    {
        public override enuJGPlayerType PlayerType
        {
            get { return enuJGPlayerType.Computer; }
        }


    }
}
