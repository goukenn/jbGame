using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JamboGame
{
    /// <summary>
    /// represent a base player class
    /// </summary>
    public abstract class JGPlayer
    {
        private string m_Name;


        public JGDBGameProfile Profile { get; set; }
        /// <summary>
        /// get or set the player Name
        /// </summary>
        public string Name
        {
            get { return m_Name; }
            set
            {
                if (m_Name != value)
                {
                    m_Name = value;
                }
            }
        }
        public abstract enuJGPlayerType PlayerType
        {
            get;
        }
        public static JGPlayer CreatePlayer(string name)
        {
            JGPlayer c = null;
            Type t = Type.GetType("JamboGame.JG" + name + "Player");
            if (t != null)
            {
                c = t.Assembly.CreateInstance(t.FullName) as JGPlayer;
            }
            return c;
        }

        public void Play(JGParty party,  JGCard jGCard)
        {
            party.Play(this, jGCard);
        }
        public override string ToString()
        {
            return string.Format ("JGPlayer : {0}",  this.Name);
        }

        internal bool RemoveFromBalance(int Balance)
        {
            return JGDB.RemoveFromBalance(this, Balance);
            
        }



        public JGGameTablePlayerProfile  CreateGameProfile(int balance)
        {
            if (this.RemoveFromBalance(balance))
            {
                JGGameTablePlayerProfile profile = new JGGameTablePlayerProfile(this, balance);
                return profile;
            }
            return null;
        }

    }
}
