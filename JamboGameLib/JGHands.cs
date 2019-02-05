using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JamboGame
{
    /// <summary>
    /// represent hands in JG Game
    /// </summary>
    public class JGHands
    {
        private JGParty jGParty;
        Dictionary<JGPlayer, JGHand> m_playerHands;
        internal  JGHands(JGParty jGParty)
        {
            
            this.jGParty = jGParty;
            this.m_playerHands = new Dictionary<JGPlayer, JGHand>();
        }

        internal void AddCard(JGPlayer item, JGCard[] jGCard)
        {

            if (!this.m_playerHands.ContainsKey(item))
                this.m_playerHands.Add(item, new JGHand(this.jGParty, item));
             this.m_playerHands[item].AddCard(jGCard);
        }
        public JGHand GetHand(JGPlayer item)
        {
            return this.m_playerHands[item];
        }

        public void SortHand(JGComputerPlayer player1)
        {
            GetHand(player1).SortByValue ();
        }

        public void SortHand(JGComputerPlayer player1, enuJGSortType enuJGSortType)
        {
            switch (enuJGSortType)
            {
                case enuJGSortType.Color:
                    GetHand(player1).SortByColor();
                    break;
                case enuJGSortType.Type:
                    GetHand(player1).SortByType();
                    break;
                case enuJGSortType.Value:
                    GetHand(player1).SortByValue();
                    break;
                default:
                    break;
            }
        }
    }
}
