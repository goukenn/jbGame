using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JamboGame
{
    public class JGPartyEndEventArgs : EventArgs 
    {
        private JGPlayer  m_Winner;
        private enuJGPartyEndReason m_Reason;
        private enuJGExceptionRule  m_Rule;

        public enuJGExceptionRule  Rule
        {
            get { return m_Rule; }
            set{
                m_Rule = value;
            }
          
        }

      

        public enuJGPartyEndReason Reason

        {
            get { return m_Reason; }
            set
            {
                if (m_Reason != value)
                {
                    m_Reason = value;
                }
            }
        }
        

        public JGPlayer  Winner
        {
            get { return m_Winner; }
            set
            {
                if (m_Winner != value)
                {
                    m_Winner = value;
                }
            }
        }
        public JGPartyEndEventArgs()
        {

        }
        public JGPartyEndEventArgs(JGPlayer player, enuJGPartyEndReason reason, enuJGExceptionRule exRule)
        {
            this.m_Winner = player;
            this.m_Reason = reason;
            this.m_Rule = exRule;
        }
    }
}
