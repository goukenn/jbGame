using IGK.DrSStudio;
using IGK.DrSStudio.Codec;
using IGK.DrSStudio.Drawing2D;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JamboGameWinUI.WinUI
{
    public partial class JBGameMainForm : JBGameForm
    {
        public JBGameMainForm()
        {
            InitializeComponent();
        }

        internal static void InitAndRun(JBGameStartForm startForm)
        {
            Thread th = new Thread(new JBMainFormLauncher(startForm).LoadMainForm);
            th.SetApartmentState(ApartmentState.STA);
            th.IsBackground = false;
            th.Start();
        }

        class JBMainFormLauncher
        {
            private JBGameStartForm startForm;
            private JBGameMainForm m_mainForm;

            public JBMainFormLauncher(JBGameStartForm startForm)
            {                
                this.startForm = startForm;

            }

            internal  void LoadMainForm()
            {
                m_mainForm = new JBGameMainForm();
                m_mainForm.Load += m_mainForm_Load;
                //initialize the main form
                
                try
                {
                    CoreSystem.Init();
                    Application.Run(m_mainForm);
                }
                catch(Exception ex) {
                    JBGameExceptionDialog.ShowException(ex, "MainForm");
                }
            }

            void m_mainForm_Load(object sender, EventArgs e)
            {
                this.startForm.Invoke((MethodInvoker)this.startForm.Close);

            }
        }
        ICore2DDrawingDocument bg_document;
        private void JBGameMainForm_Load(object sender, EventArgs e)
        {
            this.Location = Properties.Settings.Default.MainFormLocation;

            this.LocationChanged += JBGameMainForm_LocationChanged;
            Application.ApplicationExit += Application_ApplicationExit;
            //bg_document = CoreDecoder.Instance.Open2DDocument (Properties.Resources.border_doc).First();

            string[] t = CoreSystem.Instance.WorkingObjects.GetWorkingObjectList();
            Array.Sort(t);
            this.listBox1.DataSource = t;
            
        }

        protected override void OnPaintBackground(PaintEventArgs e)
        {
            //base.OnPaintBackground(e);
            //do nothing
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            
            if (bg_document != null)
            {
                bg_document.Draw(e.Graphics,false, this.ClientRectangle, enuFlipMode.None  );
            }
            base.OnPaint(e);
        }

        void Application_ApplicationExit(object sender, EventArgs e)
        {
            Properties.Settings.Default.Save();
        }

        void JBGameMainForm_LocationChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.MainFormLocation = this.Location;
            
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
