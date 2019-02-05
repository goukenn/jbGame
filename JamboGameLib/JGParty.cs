using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#pragma warning disable

namespace JamboGame
{
    /// <summary>
    /// represent a game partie
    /// </summary>
    public partial  class JGParty 
    {
        private JGPartyPlayerCollections m_players;
        private JGBank m_Bank;
        private JGPlayer m_SelectedPlayer;
        private JGHands m_hands;
        private JGGameHand m_gameHand;

        private bool m_GameStart;


        public event EventHandler<JGPartyEndEventArgs> PartyEnd;


#if JGGAME_CHECK

        public void DistributeFourSeventToPlayer(JGPlayer player)
        {
            this.m_Bank.Distribute4Seven(player);
        }
        public void DistributeThreeSeventToPlayer(JGPlayer player)
        {
            this.m_Bank.Distribute3Seven(player);
        }
        public void Distribute21ToPlayer(JGPlayer player)
        {
            this.m_Bank.Distribute21(player);
        }
#endif
        public bool GameStart
        {
            get { return m_GameStart; }
        }

        public JGPlayer SelectedPlayer
        {
            get { return m_SelectedPlayer; }
            set {
                if (this.m_SelectedPlayer != value )
                {
                    this.m_SelectedPlayer = value;
                    OnSelectedPlayerChanged(EventArgs.Empty);
                }
                CheckForEnd();
            }
        }

        private void CheckForEnd()
        {
            if (this.m_GameStart)
            {
                JGHand h = this.Hands.GetHand(m_SelectedPlayer);
                if (h.IsEmpty)
                {
                    this.Winner = this.m_gameHand.ControlUser;
                    this.m_GameStart = false;
                    OnPartyEnded(new JGPartyEndEventArgs(this.Winner, enuJGPartyEndReason.Normal, enuJGExceptionRule.None)); 
                }
            }
        }
        public event EventHandler SelectedPlayerChanged;
        ///<summary>
        ///raise the SelectedPlayerChanged 
        ///</summary>
        protected virtual void OnSelectedPlayerChanged(EventArgs e)
        {
            if (SelectedPlayerChanged != null)
                SelectedPlayerChanged(this, e);
        }

        protected virtual void OnPartyEnded(JGPartyEndEventArgs  e)
        { 
            if (this.PartyEnd !=null)
                this.PartyEnd (this, e);
        }
     
        public JGBank Bank
        {
            get { return m_Bank; }
        }
        public JGHands Hands {
            get {
                return this.m_hands;
            }
        }
        public JGPartyPlayerCollections Players { get { return this.m_players;  } }
        /// <summary>
        /// .ctr
        /// </summary>
        private JGParty()
        {
            m_players = new JGPartyPlayerCollections(this);
            m_Bank = new JGBank(this);
            m_hands = new JGHands(this);
            m_gameHand = new JGGameHand(this);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="player1"></param>
        /// <param name="player2">list des player additionel seul 3 seront considéré</param>
        /// <returns>un nouvelle party</returns>
        public static JGParty CreateParty(JGPlayer player1, params  JGPlayer[] player2)
        {
            if ((player2 == null) || (player2 .Length == 0))
                return null;
            JGParty v_p = new JGParty();
            v_p.m_players.Add(player1);
            for (int i = 0; i < player2.Length ; i++)
            {
                if (!v_p.AddPlayer(player2[i])) break;
            }
            
            return v_p;
        }
        /// <summary>
        /// add a player to the party
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        public bool AddPlayer(JGPlayer p)
        {
            if (this.m_players.Count < JGConstant.MAX_PLAYER_GAME)
            {
                return this.m_players.Add(p);                
            }
            return false;
        }


        public void MixCard()
        {
            if (this.m_GameStart) return; 
            this.Bank.MixCard();
        }
        public void CutAt(int position)
        {
            if (this.m_GameStart) return; 
            this.Bank.CutAt(position );
        }
        /// <summary>
        /// start a new party
        /// </summary>
        public void Start()
        {
            //check for requirement before start party
            if (this.m_GameStart)
                return;

            if (this.SelectedPlayer == null)
                this.SelectedPlayer = this.Players[0];
#if JGGAME_CHECK
            //this.Bank.Distribute4Seven (this.SelectedPlayer);
            this.Bank.Distribute21(this.SelectedPlayer);

            foreach (JGPlayer item in this.m_players)
            {
                JGHand hand = this.m_hands.GetHand(item);
                Console.WriteLine("Card For Player =  " + item.Name);
                foreach (JGCard  card in hand)
                {
                    Console.WriteLine("->" + card.ToString());
                }
            }

#else
            this.Bank.Distribute();


#endif
            this.m_GameStart = true;
        }


        /// <summary>
        /// play the player card
        /// </summary>
        /// <param name="player"></param>
        /// <param name="card"></param>
        internal void Play(JGPlayer player, JGCard card)
        {
            this.m_gameHand.Play(player, card);
        }

        public bool End { get { return !this.m_GameStart; } }

        /// <summary>
        /// get the control card
        /// </summary>
        public JGCard  ControlCard { get{return this.m_gameHand.ControlCard ;} }

        public JGPlayer ControlUser{get{return this.m_gameHand.ControlUser ; }}

        public JGPlayer Winner { get; protected set; }

        public int Tour { get { return this.m_gameHand.Tour; } }

        public bool CheckMyRules(JGPlayer player)
        {
            //check for confidition
            if (this.Tour == 0)
            {
                JGHand hand =  this.m_hands.GetHand(player);
                if (hand != null)
                {
                    enuJGExceptionRule c = hand.IsSevenRule() | hand.IsTweentyOneRule ();
                    if (c != enuJGExceptionRule.None)
                    {
                        this.m_GameStart = false;
                        this.m_gameHand.ControlUser = player;
                        this.Winner = player;
                        JGPartyEndEventArgs e = new JGPartyEndEventArgs();
                        e.Winner = Winner;
                        foreach (JGCard item in hand )
                        {
                            Console.WriteLine("CARD " + item);
                        }
                        switch (c)
                        {
                            case enuJGExceptionRule.None:
                                break;
                            case enuJGExceptionRule.Threeseven:
                                Console.Write("ThreeSEVEN RULE");
                                
                                break;
                            case enuJGExceptionRule.FourSeven:
                                Console.Write("FourSEVEN RULE");
                                break;
                            case enuJGExceptionRule.TwentyOneRule:
                                
                                Console.Write("TwentyOneRule RULE");
                                break;
                            default:
                                break;
                        }
                        e.Reason = (c != enuJGExceptionRule.None ) ?  enuJGPartyEndReason.ExceptionRule : enuJGPartyEndReason.Normal ;
                        e.Rule = c;
                        OnPartyEnded(e);
                        return true;
                    }
                }
            }
            return false;
        }

        public enuCoraType CheckCoraRule(JGPlayer jGPlayer)
        {
            if ((this.ControlCard.Value != 3) || (!this.m_GameStart) || (this.Tour == 5))
            {
                return enuCoraType.None;
            }
            JGGameHand.JGGameHandInfo[] dd = this.m_gameHand.GetPlayerGameHandInfo(jGPlayer);
            int j = 0;
            for (int i = dd.Length-2 ; i >=1 ; i--)
            {
                if (dd[i].Card.Value != 3)
                {
                    break;
                }
                j++;

            }
            switch (j)
            {
                case 2:
                    return enuCoraType.Double;
                case 3:
                    return enuCoraType.Triple;
                case 4:
                    return enuCoraType.Impossible ;
                
            }
            return enuCoraType.Simple ;
            
        }

        internal void EjectPlayer(JGPlayer item, enuEjectReason enuEjectReason)
        {
            switch (enuEjectReason)
            {
                case enuEjectReason.PlayerAbort:
                    break;
                case enuEjectReason.CanRemoveBalance:
                    break;
                default:
                    break;
            }
        }
    }
}
