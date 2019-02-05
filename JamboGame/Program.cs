using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using WinUI = System.Windows.Forms;
using System.Drawing;
using JamboGame.WinUI;

namespace JamboGame
{
    static class Program
    {
        [STAThread]
        public static void Main( params string[] args)
        {
            try
            {
#if WINDOWS
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                StartForm v_start = new StartForm();
                v_start.Show();
                while (v_start.Created)
                {
                    Application.DoEvents();
                }
#elif ANDROID

#elif LINUX 

#elif CONSOLE 

             //   JGDB db = null;
                JGDB.StoreDb();

                Console.WriteLine("Demonstration : Welcome to JAMBO GAME");
                JGHumanPlayer player1 = new JGHumanPlayer();
                player1.Name = "Bertrand";
                player1.Profile = JGDB.GetProfile("test1@jgdb.com");
               
                JGGameTablePlayerProfile prof1 =  player1.CreateGameProfile(180);
                JGGameTablePlayerProfile prof2 =
                    new JGComputerPlayer()
                    {
                        Name = "Comp2",
                        Profile = JGDB.GetProfile("test2@jgdb.com")
                    }.CreateGameProfile(60);

                JGPartyTable table = JGPartyTable.CreateTable(50, prof1 , prof2 );
                if (table != null)
                {
                    table.Party.Start();
                    JGParty party = table.Party;
                    JGHand hand = null;
                    while (!party.End)
                    {
                        hand = party.Hands.GetHand(party.SelectedPlayer);


                        Console.WriteLine("Tour: " + party.Tour);
                        Console.WriteLine("Jeu: " + party.SelectedPlayer);
                        if (party.Tour == 0)
                        {
                            if ((hand.IsSevenRule() | hand.IsTweentyOneRule()) != enuJGExceptionRule.None)
                            {
                                //Console.WriteLine (" REGLE DES 7 : "+ hand.IsSevenRule ());
                                party.CheckMyRules(party.SelectedPlayer);
                            }
                        }
                        if ((party.ControlCard == null) || (party.ControlUser == party.SelectedPlayer))
                        {
                            party.SelectedPlayer.Play(party, hand[0]);
                        }
                        else if (hand.ContainsCardType(party.ControlCard.CardType))
                        {
                            hand.SortByType();
                            party.SelectedPlayer.Play(party, hand.GetFirstCard(party.ControlCard.CardType));
                        }
                        else
                        {
                            party.SelectedPlayer.Play(party, hand[0]);
                        }

                    }
                }
                else {
                    Console.WriteLine("can't create a table .table mis error");
                }
                JGDB.Restore(prof1, prof2);
                Console.WriteLine("Party end");
                

                /*

                JGComputerPlayer player1 = new JGComputerPlayer();
                player1.Name = "Comp1";
                JGParty party = JGParty.CreateParty(player1,
                    new JGComputerPlayer[]{
                    new JGComputerPlayer(){
                        Name = "Comp2"
                    }
                    ,
                    new JGComputerPlayer(){
                        Name = "Comp3"
                    }
                    });

                Console.WriteLine("nouvelle party " + party.Players.Count);

                party.MixCard();
                party.CutAt(21);

                party.Start();
                JGHand hand = null;// party.Hands.GetHand(party.SelectedPlayer);

                

                while (!party.End)
                {
                    hand = party.Hands.GetHand(party.SelectedPlayer);

                    
                    Console.WriteLine("Tour: " + party.Tour);
                    Console.WriteLine("Jeu: "+party.SelectedPlayer);
                    if (party.Tour== 0)
                    {
                        if ((hand.IsSevenRule() | hand.IsTweentyOneRule ()) != enuJGExceptionRule.None)
                        { 
                            //Console.WriteLine (" REGLE DES 7 : "+ hand.IsSevenRule ());
                            party.CheckMyRules(party.SelectedPlayer );
                        }
                    }
                    if ((party.ControlCard == null) || (party.ControlUser == party.SelectedPlayer ))
                    {
                        party.SelectedPlayer.Play(party, hand[0]);
                    }
                    else if (hand.ContainsCardType (party.ControlCard.CardType))
                    {
                        hand.SortByType();
                        party.SelectedPlayer.Play(party, hand.GetFirstCard(party.ControlCard.CardType));
                    }
                    else {
                            party.SelectedPlayer.Play(party, hand[0]);
                    }
                  
                }
                Console.WriteLine("party teminer:  ");
                Console.WriteLine ("Winner : "+ party.Winner);
                Console.WriteLine ("Card : "+ party.ControlCard );

                

                if ((party.Tour == 5))
                {
                    party.CheckCoraRule(party.Winner);
                }
                */

                //Console.WriteLine("party teminer " + party.Winner);
                

              //  JGHand hand = party.Hands.GetHand(player1);

               // Console.WriteLine ("jour 1 jouer");

                //player1.Play(party, hand[0]);



                //Console.WriteLine("Couleur Rouge : " + GetColor(hand, enuJGCardColor.Red ));                
                //Console.WriteLine("Couleur Black : " + GetColor(hand, enuJGCardColor.Black));

                //foreach (enuJGCardType item in Enum.GetValues (typeof (enuJGCardType)))
                //{
                //    Console.WriteLine("Carte " + item.ToString() + " " + GetCardType(hand, item));
                //}

                
                


                //party.Hands.SortHand(player1, enuJGSortType.Color   );                
                //hand.SortByValue();





                Console.ReadLine();
#endif

               
            }
            catch (Exception ex){
                MessageBox.Show("L'application s'est malheureusement arrêter : "+ex.Message );
                
            }
            
        }

        private static int GetColor(JGHand hand, enuJGCardColor t)
        {
            int i = 0;
            foreach (JGCard  item in hand)
            {
                if (item.GetColor() == t)
                    i++;
            }
            return i;
        }
        private static int GetCardType(JGHand hand, enuJGCardType  t)
        {
            int i = 0;
            foreach (JGCard item in hand)
            {
                if (item.CardType == t)
                    i++;
            }
            return i;
        }

        
    }
}
