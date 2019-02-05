using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JamboGame
{
     public static class JGHandException
    {
        public static JGCard[] GetAllCard(this Array tvalue, int value)
        {
            List<JGCard> c = new List<JGCard>();
            for (int i = 0; i < tvalue.Length; i++)
            {
                if ( (tvalue.GetValue (i) as JGCard ).Value == value)
                    c.Add( (tvalue.GetValue (i) as JGCard ));
            }
            return c.ToArray();
        }

        public static JGCard[] CopyFrom(this JGCard[] t, int index, int length)
        {
            JGCard[] tab = new JGCard[length];
            Array.Copy(t, index, tab, 0, length);
            return tab;
        }

        public static enuJGExceptionRule IsSevenRule(this JGHand hand)
        {
            if (hand.Count != 5)
                return enuJGExceptionRule.None;
            int i = 0;
            foreach(JGCard card in hand)
            {
                if (card.Value == 7) i++;
            }
            switch (i)
            {
                case 3: return enuJGExceptionRule.Threeseven;
                case 4: return enuJGExceptionRule.FourSeven ;
            }
            return enuJGExceptionRule.None;
        }
        public static enuJGExceptionRule IsTweentyOneRule(this JGHand hand)
        {
            if (hand.Count != 5)
                return enuJGExceptionRule.None;
            int i = 0;
            foreach (JGCard card in hand)
            {
                 i+=card.Value ;
            }
            return (i<=21)? enuJGExceptionRule.TwentyOneRule : enuJGExceptionRule.None ;
        }
    }
}
