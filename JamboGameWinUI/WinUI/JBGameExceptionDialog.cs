using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JamboGameWinUI.WinUI
{
    class JBGameExceptionDialog : CommonDialog
    {
        public static void ShowException(Exception ex)
        {
            
        }
        public static void ShowException(Exception ex, string title)
        {
            throw new NotImplementedException();
        }
        public override void Reset()
        {
            throw new NotImplementedException();
        }

        protected override bool RunDialog(IntPtr hwndOwner)
        {
            throw new NotImplementedException();
        }

      
    }
}
