using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JamboGame
{
    public class JGGameHand
    {
        JGParty jGParty;
        private JGCard m_ControlCard;
        private JGPlayer m_ControlUser;
        int m_count;
        int m_tour;

        Dictionary<int, List<JGGameHandInfo>> m_dic;

        public JGPlayer ControlUser
        {
            get { return m_ControlUser; }
            internal set { this.m_ControlUser = value; }
        }
        public JGCard ControlCard
        {
            get { return m_ControlCard; }
        }
        internal JGGameHand(JGParty jGParty)
        {
            this.jGParty = jGParty;
            this.m_tour = 0;
            this.m_dic = new Dictionary<int, List<JGGameHandInfo>>();

        }
        public JGGameHandInfo[] GetPlayerGameHandInfo(JGPlayer player)
        {
            List<JGGameHandInfo> t = new List<JGGameHandInfo>();
            foreach (KeyValuePair<int,List<JGGameHandInfo>>  item in m_dic)
            {

                var b = from s in item.Value where s.Player  == player select s ;//.Select(from s in this select s);
                foreach (JGGameHandInfo  ts in b)
                {
                    t.Add(ts); 
                }
         
            }
            return t.ToArray ();
        }
        public void Play(JGPlayer player, JGCard card)
        {
            if ((player == this.jGParty.SelectedPlayer) && (card !=null))
            {
                JGHand hand =  this.jGParty.Hands.GetHand(player);
                if (hand.Contains(card))
                {
                    if (
                        (this.ControlCard == null) ||
                        (this.m_ControlUser == player) ||
                        (card.CardType == this.ControlCard.CardType) ||
                        !hand.ContainsCardType(this.ControlCard.CardType)
                      )
                    {
#if DEBUG
                        Console.WriteLine("card : " + card);
#endif
                        //peux jouer
                        int vtour = m_count / this.jGParty.Players.Count;
                        if (!this.m_dic.ContainsKey(vtour))
                        {
                            this.m_dic.Add(vtour, new List<JGGameHandInfo>());
                        }
                        this.m_dic[vtour].Add(new JGGameHandInfo()
                        {
                            Player = player,
                            Card = card,
                            JGParty = jGParty,
                            Tour = vtour,
                            Index = m_count
                        });

                        if ((this.ControlUser == null) || (this.ControlUser == player ))
                        {
                            this.m_ControlUser = player;
                            this.m_ControlCard = card;
                        }
                        else if
                            ((card.CardType == this.ControlCard.CardType) &&
                            (card.Value > this.ControlCard.Value))
                        {
                            this.m_ControlCard = card;
                            this.m_ControlUser = player;
                        }
                        m_count++;
                        int tt = m_count / this.jGParty.Players.Count;

                        hand.Remove(card);

                        if (tt != vtour)
                        {
                            this.m_tour = tt;
                            Console.WriteLine();
                            this.jGParty.SelectedPlayer = this.m_ControlUser;
                        }
                        else
                        {
                            this.jGParty.SelectedPlayer = this.jGParty.Players[((this.jGParty.Players.IndexOf(player) + 1) % this.jGParty.Players.Count)];
                            
                        }

                    }
                    else {
                        System.Diagnostics.Debug.WriteLine ("Ne pas pue jouer la carte " + card.ToString());
                    }


                }
                else {
                    System.Diagnostics.Debug.WriteLine ("Ne possède pas la carte");
                }
            }
        }


        public class JGGameHandInfo
        {
            private int m_Tour;
            private JGParty m_JGParty;
            private JGCard m_Card;
            private JGPlayer  m_Player;
            private int m_Index;

            public int Index
            {
                get { return m_Index; }
                set
                {
                    if (m_Index != value)
                    {
                        m_Index = value;
                    }
                }
            }

            public JGPlayer  Player
            {
                get { return m_Player; }
                internal set
                {
                    if (m_Player != value)
                    {
                        m_Player = value;
                    }
                }
            }
            public JGCard Card
            {
                get { return m_Card; }
                internal set
                {
                    if (m_Card != value)
                    {
                        m_Card = value;
                    }
                }
            }
            public JGParty JGParty
            {
                get { return m_JGParty; }
                set
                {
                    if (m_JGParty != value)
                    {
                        m_JGParty = value;
                    }
                }
            }
            public int Tour
            {
                get { return m_Tour; }
                set
                {
                    if (m_Tour != value)
                    {
                        m_Tour = value;
                    }
                }
            }
        }

        public int Tour { get { return this.m_tour; } }
    }
}
