using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JamboGame
{
    /// <summary>
    /// represent a human player
    /// </summary>
    public class JGHumanPlayer : JGPlayer 
    {
        public override enuJGPlayerType PlayerType
        {
            get { return enuJGPlayerType.Player; }
        }
    }
}
