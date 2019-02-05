using JamboGame.WinUI;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace JamboGame.Renderer
{
    class JGCardRenderer : JGLayerFrame
    {
        private UIGameTable uIGameTable;

        public JGCardRenderer(UIGameTable uIGameTable)
        {
            
            this.uIGameTable = uIGameTable;
        }
        public override void Render(System.Drawing.Rectangle rectangle, System.Drawing.Graphics graphics)
        {
            
            GraphicsState s = graphics.Save();
            
            Rectangle rt = new System.Drawing.Rectangle(0, 0, 57, 88);
          
            graphics.TranslateTransform(- rt.Width  / 2,  -rt.Height  / 2, MatrixOrder.Append );
            graphics.RotateTransform(20, MatrixOrder.Append );            
            graphics.TranslateTransform(((rectangle.X + rectangle.Width)) / 2, ((rectangle.Y + rectangle.Height)) / 2, MatrixOrder.Append);
            
 
            graphics.FillRectangle(Brushes.White, rt);
            graphics.Restore(s);
        }
    }
}
