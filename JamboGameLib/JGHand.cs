using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JamboGame
{
    /// <summary>
    /// represent a party player hand
    /// </summary>
    public class JGHand: IEnumerable,  IComparer<JGCard>
    {
        
        private List<JGCard> m_cards;
        private JGParty m_party;
        private JGPlayer m_player;
        private enuJGSortType m_sortType;
        public bool IsEmpty {
            get {
                return (m_cards.Count == 0);
            }
        }

        public int Count { get{return this.m_cards.Count ;} }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public JGCard this[int index] { get {
            if (this.IsEmpty)
                return null;
            return this.m_cards[index]; 
        } }
        

        internal  JGHand( JGParty party, JGPlayer player)
        {
            m_cards = new List<JGCard>();
            this.m_party = party;
            this.m_player = player;
        }


        public void AddCard(params JGCard[] card)
        {
            if (card != null)
                this.m_cards.AddRange(card);
        }

        public void SortByColor() {
            this.m_sortType = enuJGSortType.Color;
            m_cards.Sort(this);
        }
        public void SortByType() {
            this.m_sortType = enuJGSortType.Type ;
            m_cards.Sort(this);
        }
        public void SortByValue() {
            this.m_sortType = enuJGSortType.Value;
            m_cards.Sort(this);
        }


        public int Compare(JGCard x, JGCard y)
        {
            switch (this.m_sortType)
            {
                case enuJGSortType.Color:
                    if (x.GetColor() == y.GetColor())
                    {
                        goto case enuJGSortType.Type;
                    }
                    else {
                        if (x.GetColor() == enuJGCardColor.Red)
                            return -1;
                        else
                            return 1;
                    }
                case enuJGSortType.Type:
                    if (x.CardType == y.CardType)
                    {
                        goto case enuJGSortType.Value;
                    }
                    else {
                        if (x.GetColor() == y.GetColor())
                        {
                            if (x.GetColor() == enuJGCardColor.Red)
                            {
                                if (x.CardType == enuJGCardType.Diamonds)
                                    return -1;
                                return 1;
                            }
                            else
                            {
                                if (x.CardType == enuJGCardType.Clover)
                                    return -1;
                                return 1;
                            }
                        }
                        else {
                            goto case enuJGSortType.Color;
                        }                       
                    }
                case enuJGSortType.Value:
                    if (x.Value == y.Value )
                        goto case enuJGSortType.Color;
                    else
                        return x.Value.CompareTo(y.Value);                    
                default:
                    break;
            }
            return 0;
        }

        public IEnumerator GetEnumerator()
        {
            return this.m_cards.GetEnumerator();
        }

        public bool ContainsCardType(enuJGCardType carType)
        {            
            foreach (JGCard item in this)
            {
                if (item.CardType == carType)
                    return true;
            }
            return false;
        }

        internal bool Contains(JGCard card)
        {
            return this.m_cards.Contains(card);
        }

        internal void Remove(JGCard card)
        {
            this.m_cards.Remove(card);
        }

        public JGCard GetFirstCard(enuJGCardType t)
        {
            foreach (JGCard item in this)
            {
                if (item.CardType == t)
                    return item;
            }
            return null;
        }
    }
}
