using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JamboGame
{
    /// <summary>
    /// reprsent a player info
    /// </summary>
    class JGPlayerInfo
    {
        private int m_Balance;

        public int Balance
        {
            get { return m_Balance; }
            set
            {
                if (m_Balance != value)
                {
                    m_Balance = value;
                }
            }
        }
    }
}
