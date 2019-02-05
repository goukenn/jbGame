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
    public partial class MainForm : Form
    {

        private string m_LoadingMessage;

        public string LoadingMessage
        {
            get { return m_LoadingMessage; }
            set
            {
                if (m_LoadingMessage != value)
                {
                    m_LoadingMessage = value;
                    OnLoadingMessageChanged(EventArgs.Empty);
                }
            }
        }

        public event EventHandler LoadingMessageChanged;
        ///<summary>
        ///raise the LoadingMessageChanged 
        ///</summary>
        protected virtual void OnLoadingMessageChanged(EventArgs e)
        {
            if (LoadingMessageChanged != null)
                LoadingMessageChanged(this, e);
        }

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {


            /*this.webBrowser1.DocumentText = @"<html style=""width:100%; height:100%; padding:0px; margin:0px;"" >
<body style=""width:100%; height:100%; padding:0px; margin:0px; "" >
<form style=""position:relative; height:100%; background-color: red; width:100%; box-shadow:0px 0px 3px black; "">
<div id=""connectionTag"" class=""igk-config-conexion-div"">
<div id=""LayerDocument_52559464"" style="" width:300px; height:400px; position:relative; color:white;  display:inline-block;"" >
 
<div id=""id_layer"" style=""width:300px; height:400px; z-index:0; position:absolute;"">
<div id=""id_board""  style=""width:301px; height:401px; position:absolute; padding-top: 48px; background-repeat:no-repeat; background-image: url('data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAAS0AAAGRCAYAAAAw6+XgAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAAU5SURBVHhe7dSxCcAwAANB7b+bZ0ogtQfIwwmuUv/bzgPQ8O12APyRaAEpogWkiBaQIlpAimgBKaIFpIgWkCJaQIpoASmiBaSIFpAiWkCKaAEpogWkiBaQIlpAimgBKaIFpIgWkCJaQIpoASmiBaSIFpAiWkCKaAEpogWkiBaQIlpAimgBKaIFpIgWkCJaQIpoASmiBaSIFpAiWkCKaAEpogWkiBaQIlpAimgBKaIFpIgWkCJaQIpoASmiBaSIFpAiWkCKaAEpogWkiBaQIlpAimgBKaIFpIgWkCJaQIpoASmiBaSIFpAiWkCKaAEpogWkiBaQIlpAimgBKaIFpIgWkCJaQIpoASmiBaSIFpAiWkCKaAEpogWkiBaQIlpAimgBKaIFpIgWkCJaQIpoASmiBaSIFpAiWkCKaAEpogWkiBaQIlpAimgBKaIFpIgWkCJaQIpoASmiBaSIFpAiWkCKaAEpogWkiBaQIlpAimgBKaIFpIgWkCJaQIpoASmiBaSIFpAiWkCKaAEpogWkiBaQIlpAimgBKaIFpIgWkCJaQIpoASmiBaSIFpAiWkCKaAEpogWkiBaQIlpAimgBKaIFpIgWkCJaQIpoASmiBaSIFpAiWkCKaAEpogWkiBaQIlpAimgBKaIFpIgWkCJaQIpoASmiBaSIFpAiWkCKaAEpogWkiBaQIlpAimgBKaIFpIgWkCJaQIpoASmiBaSIFpAiWkCKaAEpogWkiBaQIlpAimgBKaIFpIgWkCJaQIpoASmiBaSIFpAiWkCKaAEpogWkiBaQIlpAimgBKaIFpIgWkCJaQIpoASmiBaSIFpAiWkCKaAEpogWkiBaQIlpAimgBKaIFpIgWkCJaQIpoASmiBaSIFpAiWkCKaAEpogWkiBaQIlpAimgBKaIFpIgWkCJaQIpoASmiBaSIFpAiWkCKaAEpogWkiBaQIlpAimgBKaIFpIgWkCJaQIpoASmiBaSIFpAiWkCKaAEpogWkiBaQIlpAimgBKaIFpIgWkCJaQIpoASmiBaSIFpAiWkCKaAEpogWkiBaQIlpAimgBKaIFpIgWkCJaQIpoASmiBaSIFpAiWkCKaAEpogWkiBaQIlpAimgBKaIFpIgWkCJaQIpoASmiBaSIFpAiWkCKaAEpogWkiBaQIlpAimgBKaIFpIgWkCJaQIpoASmiBaSIFpAiWkCKaAEpogWkiBaQIlpAimgBKaIFpIgWkCJaQIpoASmiBaSIFpAiWkCKaAEpogWkiBaQIlpAimgBKaIFpIgWkCJaQIpoASmiBaSIFpAiWkCKaAEpogWkiBaQIlpAimgBKaIFpIgWkCJaQIpoASmiBaSIFpAiWkCKaAEpogWkiBaQIlpAimgBKaIFpIgWkCJaQIpoASmiBaSIFpAiWkCKaAEpogWkiBaQIlpAimgBKaIFpIgWkCJaQIpoASmiBaSIFpAiWkCKaAEpogWkiBaQIlpAimgBKaIFpIgWkCJaQIpoASmiBaSIFpAiWkCKaAEpogWkiBaQIlpAimgBKaIFpIgWkCJaQIpoASmiBaSIFpAiWkCKaAEpogWkiBaQIlpAimgBKaIFpIgWkCJaQIpoASmiBaSIFpAiWkCKaAEpogWkiBaQIlpAimgBKaIFpIgWkCJaQIpoASmiBaSIFpAiWkCKaAEpogWkiBaQIlpAimgBKaIFpIgWkCJaQIpoASmiBaSIFpAiWkCKaAEpogWkiBaQIlpAimgBKaIFpIgWkCJaQIpoASmiBaSIFpAiWkCKaAEpogWkmJmltr04BXpXuO4PkAAAAABJRU5ErkJggg==');left:0px; top:0px;"">
	<ul  >
	<li><label class=""cllabel"" >Login</label><input type=""text"" name=""login"" class=""cltext"" /><br /></li>
	<li><label class=""cllabel"" >Password</label><input type=""password"" name=""pwd"" class=""clpassword"" /><br /></li>
	</ul>	
	<br /><br />
	<li><input type=""submit"" class=""clsubmit"" name=""connect"" value=""connexion"" onclick=""javascript:window.external.Show(); alert(navigator.appVersion); return false;""/></li>	
	
</div>
<div id=""id_content"" style=""width:301px; height:131px; position:absolute;background-repeat:no-repeat; background-image: url('data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAAS0AAACDCAYAAADYgk3EAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAAIqSURBVHhe7cnBCcAwAAOxDNv9Z2jw2wM4oAO97tw+gEekNgAWpTYAFqU2ABalNgAWpTYAFqU2ABalNgAWpTYAFqU2ABalNgAWpTYAFqU2ABalNgAWpTYAFqU2ABalNgAWpTYAFqU2ABalNgAWpTYAFqU2ABalNgAWpTYAFqU2ABalNgAWpTYAFqU2ABalNgAWpTYAFqU2ABalNgAWpTYAFqU2ABalNgAWpTYAFqU2ABalNgAWpTYAFqU2ABalNgAWpTYAFqU2ABalNgAWpTYAFqU2ABalNgAWpTYAFqU2ABalNgAWpTYAFqU2ABalNgAWpTYAFqU2ABalNgAWpTYAFqU2ABalNgAWpTYAFqU2ABalNgAWpTYAFqU2ABalNgAWpTYAFqU2ABalNgAWpTYAFqU2ABalNgAWpTYAFqU2ABalNgAWpTYAFqU2ABalNgAWpTYAFqU2ABalNgAWpTYAFqU2ABalNgAWpTYAFqU2ABalNgAWpTYAFqU2ABalNgAWpTYAFqU2ABalNgAWpTYAFqU2ABalNgAWpTYAFqU2ABalNgAWpTYAFqU2ABalNgAWpTYAFqU2ABalNgAWpTYAFqU2ABalNgAWpTYAFqU2ABalNgAWpTYAFqU2ABalNgAWpTYAFqU2ABalNgAWpTYAFqU2ABalNgAWpTYAFqU2ABalNgAWpTYAFqU2ABalNgAWpTYAFqU2ABalNgAWpTYAFqU2ABZJ0kud8wN9z4XWBD/VeQAAAABJRU5ErkJggg==');left:0px; top:270px;"">
<br />
Configuration Manager
</div>
<div id=""id_foot"" style=""width:301px; height:31px; position:absolute;background-repeat:no-repeat; background-image: url('data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAAS0AAAAfCAYAAACyJpv8AAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAACRSURBVHhe7dTBCYBAEATBzT+QS88IFMWHLwO4hhooWNh/zxzXAtjfuebd7xNgN6IFpIgWkCJaQIpoASmiBaSIFpAiWkCKaAEpogWkiBaQIlpAimgBKaIFpIgWkCJaQIpoASmiBaSIFpAiWkCKaAEpogWkiBaQIlpAimgBKaIFpIgWkCJaQMoXrecAKDAza23mBqing/ZAmi1SAAAAAElFTkSuQmCC');left:0px; top:0px;"">
	
</div>
	
</div>
</div>
	<div id=""igk_cpv""></div>
</div>
</form>
<body>

</html>";

            this.webBrowser1.ObjectForScripting = new JGScriptModel();*/
        }

        public  void Run()
        {
            try
            {
                InitEnvironment();
                //this.ShowDialog();
                Application.Run(this);
            }
            catch { 

            }
        }

        private void InitEnvironment()
        {
            this.LoadingMessage = "Initialization de l'environment...";
        }

        private void quitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (JGAboutForm frm = new JGAboutForm())
            {
                frm.Owner = this;
                frm.StartPosition = FormStartPosition.CenterParent;
                frm.ShowDialog();
            }
        }
    }
}
