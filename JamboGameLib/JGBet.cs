using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JamboGame
{
    /// <summary>
    /// Mis description
    /// </summary>
    class JGBet
    {
        private string m_Description;
        private int m_Amount;

        /// <summary>
        /// montant
        /// </summary>
        public int Amount
        {
            get { return m_Amount; }
            set
            {
                if (m_Amount != value)
                {
                    m_Amount = value;
                }
            }
        }
        /// <summary>
        /// Get description
        /// </summary>
        public string Description
        {
            get { return m_Description; }
            set
            {
                if (m_Description != value)
                {
                    m_Description = value;
                }
            }
        }
    }
}
