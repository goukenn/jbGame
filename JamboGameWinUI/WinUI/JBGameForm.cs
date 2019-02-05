using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JamboGameWinUI.WinUI
{
    public class JBGameForm : System.Windows.Forms.Form 
    {
        public JBGameForm()
        {
            this.SetStyle(System.Windows.Forms.ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(System.Windows.Forms.ControlStyles.OptimizedDoubleBuffer, true);
            this.SetStyle(System.Windows.Forms.ControlStyles.ResizeRedraw, true);
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // JBGameForm
            // 
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Name = "JBGameForm";
            this.Load += new System.EventHandler(this.JBGameForm_Load);
            this.ResumeLayout(false);

        }

        private void JBGameForm_Load(object sender, EventArgs e)
        {

        }
    }
}
