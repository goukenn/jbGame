using JamboGameWinUI.WinUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JamboGameWinUI
{
    class Program
    {
        [STAThread ()]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(true);
            try
            {
                Application.Run(new JBGameStartForm());
            }
            catch (Exception ex){
                JBGameExceptionDialog.ShowException(ex);
            }
        }
    }
}
