using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace JamboGame.WinUI
{
    class MainFormLoader
    {
        private StartForm startForm;

        public MainFormLoader(StartForm startForm)
        {            
            this.startForm = startForm;
        }
       
        internal void Init()
        {
            MainForm v_frm = new MainForm();
            v_frm.Load += v_frm_Load;
            v_frm.FormClosed += v_frm_FormClosed;
            v_frm.LoadingMessageChanged += v_frm_LoadingMessageChanged;
            v_frm.Run();
        }
        void v_frm_LoadingMessageChanged(object sender, EventArgs e)
        {
            startForm.BeginInvoke((MethodInvoker)delegate()
            {
                startForm.Message = (sender as MainForm).LoadingMessage;
            });
        }

        void v_frm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (!startForm.IsDisposed)
                startForm.BeginInvoke((MethodInvoker)startForm.Close);
        }

        void v_frm_Load(object sender, EventArgs e)
        {
            if (!startForm.IsDisposed)
                startForm.BeginInvoke((MethodInvoker)startForm.Close);
        }

    }
}
