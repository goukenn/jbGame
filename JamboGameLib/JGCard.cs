using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JamboGame
{
    /// <summary>
    /// represent a card type
    /// </summary>
    public sealed class JGCard
    {
        private enuJGCardType m_CardType;
        private int m_Value;
        private enuJGCardView m_ViewType;

        public enuJGCardView ViewType
        {
            get { return m_ViewType; }
            set
            {
                if (m_ViewType != value)
                {
                    m_ViewType = value;
                }
            }
        }

        public int Value
        {
            get { return m_Value; }
        }
        public enuJGCardType CardType
        {
            get { return m_CardType; }
        }
        internal JGCard(enuJGCardType type, int value)
        {
            this.m_CardType = type;
            this.m_Value = value;
        }

        public override string ToString()
        {
            return "Card[" + this.m_CardType + ":" + this.m_Value + "]";
        }
        /// <summary>
        /// get the card color
        /// </summary>
        /// <returns></returns>
        public enuJGCardColor  GetColor()
        {
            switch (this.m_CardType)
            {
                case enuJGCardType.Diamonds:                    
                case enuJGCardType.Hearts:
                    return enuJGCardColor.Red;                    
                case enuJGCardType.Spade:                    
                case enuJGCardType.Clover:
                default :
                    return enuJGCardColor.Black;
            }
            
        }
    }
}
