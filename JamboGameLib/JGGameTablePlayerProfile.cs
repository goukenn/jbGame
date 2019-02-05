using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JamboGame
{
    /// <summary>
    /// get game player profile on table
    /// </summary>
    public class JGGameTablePlayerProfile
    {
        private JGPlayer m_Player;
        private int m_Balance;

        public int TableBalance
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
        public JGPlayer Player
        {
            get { return m_Player; }
           
        }

        internal bool RemoveFromBalance(int Balance)
        {
            if (this.m_Balance >= Balance)
            {
                this.m_Balance -= Balance;
                return true;
            }
            return false;
        }

        public void Restore()
        {
            if (JGDB.RestoreBalance(this))
            {
                this.m_Balance = 0;
            }
        }


        public JGGameTablePlayerProfile(JGPlayer player, int balance)
        {
            this.m_Balance = balance;
            this.m_Player = player;
        }
    }
}
