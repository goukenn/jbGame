using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JamboGame
{
    public partial class JGPartyTable
    {
        /// <summary>
        /// represent a human observer collection
        /// </summary>
        class JGHumanObserverCollection : IEnumerable
        {
            List<JGHumanPlayer> m_observers;
            JGPartyTable m_table;

            public JGHumanObserverCollection(JGPartyTable table)
            {
                this.m_table = table;
                this.m_observers = new List<JGHumanPlayer>();
            }

            public IEnumerator GetEnumerator()
            {
                return this.m_observers.GetEnumerator();
            }

            internal void Add(JGHumanPlayer human)
            {
                this.m_observers.Add(human);
            }

            internal void Remove(JGHumanPlayer human)
            {
                this.m_observers.Remove(human);
            }
        }
    }
}
