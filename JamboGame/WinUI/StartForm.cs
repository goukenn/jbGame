using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JamboGame.WinUI
{
    public partial class StartForm : Form
    {
        public StartForm()
        {
            InitializeComponent();
        }

        private void StartForm_Load(object sender, EventArgs e)
        {
            this.BackgroundImage = R.getImage(JGConstant.STARTUP_IMG);
            this.label1.Text = "Chargement ... ";
          
            Thread v_th = new Thread(new MainFormLoader(this).Init);
            v_th.SetApartmentState (ApartmentState.STA );
            v_th.Start();
        }




        public string Message { get { return this.label1.Text; } set { this.label1.Text = value; } }
    }
}
