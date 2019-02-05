using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using JamboGame.Renderer;

namespace JamboGame.WinUI
{
    public partial class UIGameTable : UserControl
    {
        LayerFrameCollections m_frames;

        /// <summary>
        /// get the frame collection
        /// </summary>
        public LayerFrameCollections LayerFrames
        {
            get {
                return this.m_frames;
            }
        }

        public UIGameTable()
        {
            m_frames = new LayerFrameCollections(this);
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            this.m_frames.Add(new JGCardRenderer(this));
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Rectangle rc = this.ClientRectangle ;
            GraphicsState s = e.Graphics.Save ();
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            rc.Inflate (-60, -60);
            e.Graphics.FillEllipse(Brushes.DarkGreen, rc);
            e.Graphics.DrawEllipse(Pens.White, rc);


            //render game engine
            e.Graphics.FillRectangle(Brushes.SkyBlue, new Rectangle(0, 0, this.ClientRectangle.Width-1, 32));

            foreach (JGLayerFrame item in this.m_frames)
            {
                item.Render(this.ClientRectangle, e.Graphics);
            }

            e.Graphics.Restore (s);
        }

        
    }
}
