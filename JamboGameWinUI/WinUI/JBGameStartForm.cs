using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JamboGameWinUI.WinUI
{
    public partial class JBGameStartForm : JBGameForm
    {
        public JBGameStartForm()
        {
            InitializeComponent();
        }

        private void JBGameStartForm_Load(object sender, EventArgs e)
        {
            this.BackgroundImage = Properties.Resources.splashscreen;
            this.BackgroundImageLayout = ImageLayout.Stretch;
            JBGameMainForm.InitAndRun(this);
        }
    }
}
