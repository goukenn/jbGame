using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JamboGame
{
    public partial class JGParty
    {
        /// <summary>
        /// collection de joueurs
        /// </summary>
        public class JGPartyPlayerCollections : IEnumerable
        {
            private JGParty jGParty;
            private List<JGPlayer> m_players;

            public JGPlayer this[int i] {
                get {
                    if ((i>=0) && (i< Count ))
                        return this.m_players[i];
                    return null;
                }
            }
            public JGPartyPlayerCollections(JGParty jGParty)
            {                
                this.jGParty = jGParty;
                this.m_players = new List<JGPlayer>();
                
            }
            /// <summary>
            /// nombre de joueur
            /// </summary>
            public int Count {
                get {
                    return this.m_players.Count;
                }
            }
            internal  bool  Add(JGPlayer player)
            {
                if ((player != null) && !this.m_players.Contains (player ) &&  (this.Count < JGConstant.MAX_PLAYER_GAME))
                {
                    this.m_players.Add(player);
                    return true;
                }
                return false;
            }
            /// <summary>
            /// get enumer
            /// </summary>
            /// <returns> enumérator </returns>
            public IEnumerator GetEnumerator()
            {
                return this.m_players.GetEnumerator();
            }

            public int IndexOf(JGPlayer player)
            {
                return this.m_players.IndexOf(player);
            }
        }
    }
}
