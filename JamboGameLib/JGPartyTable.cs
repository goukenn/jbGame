using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JamboGame
{
    /// <summary>
    /// party table
    /// </summary>
    public partial class JGPartyTable
    {
        private JGParty m_party;
        private JGHumanObserverCollection m_observers;
        private int m_Mise;
        private JGGameTablePlayerProfile[] m_profiles;
        private int m_Pot;

        /// <summary>
        /// get the pot
        /// </summary>
        public int Pot { get { return m_Pot; } }
        /// <summary>
        /// get the party
        /// </summary>
        public JGParty Party { get { return this.m_party; } }
        public int Mise
        {
            get { return m_Mise; }
            set
            {
                if (m_Mise != value)
                {
                    m_Mise = value;
                }
            }
        }

        private  JGPartyTable()
        {
            m_observers = new JGHumanObserverCollection(this);
        }

        public static JGPartyTable CreateTable(int Mise, JGGameTablePlayerProfile human, params JGGameTablePlayerProfile[] players)
        {
            if (Mise <= 0) 
                return null;
            if ((human == null) || (players == null) || (players.Length <= 0))
                return null;

            var t = from s in players where (s!=null) select s.Player;
            JGPlayer[] tp =  t.ToArray();

            ArrayList st = new ArrayList();
            st.Add(human);
            st.AddRange(players);
            int v_pot = 0;
            foreach (JGGameTablePlayerProfile item in st)
            {
                if (!item.RemoveFromBalance(Mise))
                {
                    //party.EjectPlayer(item.Player, enuEjectReason.CanRemoveBalance);

                    return null;
                }
                else
                {
                    v_pot += Mise;
                }
            }



            JGParty party = JGParty.CreateParty(human.Player,tp);

            if (party == null)
                return null;

         

            JGPartyTable p = new JGPartyTable();
            //p.Register(human, players);
            p.m_party = party;
            p.m_party.PartyEnd += p.m_party_PartyBetEnd;
            p.m_profiles =(JGGameTablePlayerProfile[]) st.ToArray(typeof (JGGameTablePlayerProfile));
            p.m_Pot = v_pot;
            return p;

        }

        void m_party_PartyBetEnd(object sender, JGPartyEndEventArgs e)
        {
            //
            switch (e.Reason)
            {
                case enuJGPartyEndReason.Normal:
                    var t = (from s in this.m_profiles where (s != null) && s.Player == e.Winner select s).ToArray()[0];
                    t.TableBalance += this.m_Pot;
                    
                    break;
                case enuJGPartyEndReason.ExceptionRule:
                    
                    break;
                default:
                    break;
            }
        }

        private static JGPlayer[] GetPlayers(JGGameTablePlayerProfile[] players)
        {
            List<JGPlayer> p = new List<JGPlayer>();
            foreach (var item in players)
            {
                p.Add (item.Player);
            }
            return p.ToArray();
        }

        public void Register(JGHumanPlayer human, params JGPlayer[] players)
        {
            JGParty p = JGParty.CreateParty(human, players);
            this.m_party = p;
        }
        public void RegisterObserver(JGHumanPlayer human)
        {
            this.m_observers.Add(human);
        }
        public void UnregisterObserver(JGHumanPlayer human)
        {
            this.m_observers.Remove(human);
        }

        public void RunGame()
        {
            this.m_party.PartyEnd += m_party_PartyEnd;
        }

        void m_party_PartyEnd(object sender, JGPartyEndEventArgs e)
        {
            switch (e.Reason)
            {
                case enuJGPartyEndReason.Normal:
                    break;
                case enuJGPartyEndReason.ExceptionRule:
                    break;
                default:
                    break;
            }
        }
    }
}
