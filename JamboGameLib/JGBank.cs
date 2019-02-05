using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JamboGame
{
    /// <summary>
    /// represent a Jambo game bank card
    /// </summary>
    public class JGBank : GameCardBankBase
    {
        private JGParty jGParty;
        List<JGCard> m_cards;
        internal JGBank(JGParty jGParty)
        {
            
            this.jGParty = jGParty;
            this.m_cards = new List<JGCard>();
            this.InitCardList();
        }

        protected internal override void InitCardList()
        {
            foreach (enuJGCardType type in Enum.GetValues (typeof(enuJGCardType )))
            {
                for (int i = 3; i <11; i++)
                {
                    this.m_cards.Add(new JGCard(type, i));
                }
            }

            
        }
        /// <summary>
        /// 
        /// </summary>
        internal protected  void MixCard()
        {
            //
            JGCard[] t = new JGCard[this.m_cards.Count];
            int[] i = new int[t.Length];

            Random rnd = new Random();
            List<int> tl = new List<int>();
            int b = 0;
            do
            {
                b = rnd.Next(i.Length);
                if (tl.Contains(b))
                {
                    continue;
                }
                i[tl.Count] = b;
                tl.Add(b);
                
            }
            while (tl.Count < t.Length);


            int a = 0;
            for (int j = 0; j < i.Length; j++)
            {
                t[j] = this.m_cards[i[a++]];
            }

            this.m_cards.Clear();
            this.m_cards.AddRange(t);

        }
        internal protected  override void CutAt(int position)
        { 
            if ((position >=0) && (position < this.m_cards.Count ))
            {
                
                JGCard[] t = new JGCard[this.m_cards.Count ];
                int LP = t.Length - position;
                this.m_cards.CopyTo(position, t, 0, LP);
                this.m_cards.CopyTo(0, t, LP , position);

                this.m_cards.Clear();
                this.m_cards.AddRange(t);
            }
        }



        #if JGGAME_CHECK
        protected internal void Distribute4Seven(JGPlayer player)
        {
            JGCard[] l = this.m_cards.ToArray().GetAllCard(7);
            foreach (JGCard item in l)
            {
                this.m_cards.Remove(item);
            }
            Queue<JGCard> queue = new Queue<JGCard>(this.m_cards);

            jGParty.Hands.AddCard(player,l);
            jGParty.Hands.AddCard(player,new  JGCard[] {
                            queue.Dequeue()});


            for (int i = 0; i < 2; i++)
            {
                switch (i)
                {
                    case 0:
                        if (queue.Count >= (jGParty.Players.Count * 3))
                            foreach (JGPlayer item in jGParty.Players)
                            {
                                if (item == player) continue;
                                jGParty.Hands.AddCard(item,
                                new JGCard[] {
                            queue.Dequeue(),
                            queue.Dequeue (),
                            queue.Dequeue ()}
                                );
                            }
                        break;
                    case 1:
                        if (queue.Count >= (jGParty.Players.Count * 2))
                            foreach (JGPlayer item in jGParty.Players)
                            {
                                if (item == player) continue;
                                jGParty.Hands.AddCard(item,
                                     new JGCard[] {
                            queue.Dequeue(),
                            queue.Dequeue ()}
                                     );
                            }
                        break;
                }
            }

            this.m_cards.Clear();
            this.m_cards.AddRange(queue.ToArray());
        }
        internal void Distribute3Seven(JGPlayer player)
        {
            JGCard[] l = this.m_cards.ToArray().GetAllCard(7);
            for (int i = 0; i < 3; i++)
            {
                this.m_cards.Remove(l[i]);
            }
           
            Queue<JGCard> queue = new Queue<JGCard>(this.m_cards);

            jGParty.Hands.AddCard(player, l.CopyFrom(0, 2));
            jGParty.Hands.AddCard(player, new JGCard[] {
                            queue.Dequeue(),
                            queue.Dequeue()});


            for (int i = 0; i < 2; i++)
            {
                switch (i)
                {
                    case 0:
                        if (queue.Count >= (jGParty.Players.Count * 3))
                            foreach (JGPlayer item in jGParty.Players)
                            {
                                if (item == player) continue;
                                jGParty.Hands.AddCard(item,
                                new JGCard[] {
                            queue.Dequeue(),
                            queue.Dequeue (),
                            queue.Dequeue ()}
                                );
                            }
                        break;
                    case 1:
                        if (queue.Count >= (jGParty.Players.Count * 2))
                            foreach (JGPlayer item in jGParty.Players)
                            {
                                if (item == player) continue;
                                jGParty.Hands.AddCard(item,
                                     new JGCard[] {
                            queue.Dequeue(),
                            queue.Dequeue ()}
                                     );
                            }
                        break;
                }
            }

            this.m_cards.Clear();
            this.m_cards.AddRange(queue.ToArray());
        }
        #endif
        /// <summary>
        /// 
        /// </summary>
        protected internal override void Distribute()
        {
 	
            Queue<JGCard> queue = new Queue<JGCard> (this.m_cards );
            
            for (int i = 0; i < 2; i++)
            {
                switch(i)
                { 
                    case 0:
                        if (queue.Count >= (jGParty.Players.Count  * 3))
                        foreach (JGPlayer item in jGParty.Players)
                        {
                            jGParty.Hands.AddCard(item,
                            new  JGCard[] {
                            queue.Dequeue(),
                            queue.Dequeue (),
                            queue.Dequeue ()}
                            );
                        }
                        break;
                    case 1:
                        if (queue.Count >= (jGParty.Players.Count  * 2))
                        foreach (JGPlayer item in jGParty.Players)
                        {
                            jGParty.Hands.AddCard(item,
                                 new JGCard[] {
                            queue.Dequeue(),
                            queue.Dequeue ()}
                                 );                       
                        }
                        break;
                }
            }
            this.m_cards.Clear();
            this.m_cards.AddRange(queue.ToArray());

        }




        internal void Distribute21(JGPlayer player)
        {
            JGCard[] l = this.m_cards.ToArray().GetAllCard(3);
            for (int i = 0; i < 4; i++)
            {
                this.m_cards.Remove(l[i]);
            }

            Queue<JGCard> queue = new Queue<JGCard>(this.m_cards);

            jGParty.Hands.AddCard(player, l);
            jGParty.Hands.AddCard(player, new JGCard[] {
                            queue.Dequeue()});


            for (int i = 0; i < 2; i++)
            {
                switch (i)
                {
                    case 0:
                        if (queue.Count >= (jGParty.Players.Count * 3))
                            foreach (JGPlayer item in jGParty.Players)
                            {
                                if (item == player) continue;
                                jGParty.Hands.AddCard(item,
                                new JGCard[] {
                            queue.Dequeue(),
                            queue.Dequeue (),
                            queue.Dequeue ()}
                                );
                            }
                        break;
                    case 1:
                        if (queue.Count >= (jGParty.Players.Count * 2))
                            foreach (JGPlayer item in jGParty.Players)
                            {
                                if (item == player) continue;
                                jGParty.Hands.AddCard(item,
                                     new JGCard[] {
                            queue.Dequeue(),
                            queue.Dequeue ()}
                                     );
                            }
                        break;
                }
            }

            this.m_cards.Clear();
            this.m_cards.AddRange(queue.ToArray());
        }
    }
}
