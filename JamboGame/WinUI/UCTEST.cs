using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JamboGame.WinUI
{
    public partial class UCTEST : UserControl
    {
        private enuJGPlayerType m_PlayerType;

        [DefaultValue(enuJGPlayerType.Player )]
        [Description ("le type d'utilisateur")]
        [Category(JGConstant.CAT_JG)]
        public enuJGPlayerType PlayerType
        {
            get { return m_PlayerType; }
            set
            {
                if (m_PlayerType != value)
                {
                    m_PlayerType = value;
                }
            }
        }
        public UCTEST()
        {
            InitializeComponent();
        }
    }
}
