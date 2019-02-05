namespace JamboGame.WinUI
{
    partial class UIGameEnvironment
    {
        /// <summary> 
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur de composants

        /// <summary> 
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas 
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.uiGameTable1 = new JamboGame.WinUI.UIGameTable();
            this.uiGameInfo3 = new JamboGame.WinUI.UIGameInfo();
            this.uiGameInfo2 = new JamboGame.WinUI.UIGameInfo();
            this.uiGameInfo1 = new JamboGame.WinUI.UIGameInfo();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Location = new System.Drawing.Point(11, 380);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(871, 234);
            this.panel1.TabIndex = 4;
            // 
            // uiGameTable1
            // 
            this.uiGameTable1.BackColor = System.Drawing.Color.Green;
            this.uiGameTable1.Location = new System.Drawing.Point(10, 16);
            this.uiGameTable1.Name = "uiGameTable1";
            this.uiGameTable1.Size = new System.Drawing.Size(397, 352);
            this.uiGameTable1.TabIndex = 3;
            // 
            // uiGameInfo3
            // 
            this.uiGameInfo3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.uiGameInfo3.Location = new System.Drawing.Point(413, 258);
            this.uiGameInfo3.MinimumSize = new System.Drawing.Size(300, 0);
            this.uiGameInfo3.Name = "uiGameInfo3";
            this.uiGameInfo3.Size = new System.Drawing.Size(469, 109);
            this.uiGameInfo3.TabIndex = 2;
            // 
            // uiGameInfo2
            // 
            this.uiGameInfo2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.uiGameInfo2.Location = new System.Drawing.Point(413, 137);
            this.uiGameInfo2.MinimumSize = new System.Drawing.Size(300, 0);
            this.uiGameInfo2.Name = "uiGameInfo2";
            this.uiGameInfo2.Size = new System.Drawing.Size(469, 109);
            this.uiGameInfo2.TabIndex = 1;
            // 
            // uiGameInfo1
            // 
            this.uiGameInfo1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.uiGameInfo1.Location = new System.Drawing.Point(413, 16);
            this.uiGameInfo1.MinimumSize = new System.Drawing.Size(300, 0);
            this.uiGameInfo1.Name = "uiGameInfo1";
            this.uiGameInfo1.Size = new System.Drawing.Size(469, 109);
            this.uiGameInfo1.TabIndex = 0;
            // 
            // UIGameEnvironment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.uiGameTable1);
            this.Controls.Add(this.uiGameInfo3);
            this.Controls.Add(this.uiGameInfo2);
            this.Controls.Add(this.uiGameInfo1);
            this.MinimumSize = new System.Drawing.Size(520, 0);
            this.Name = "UIGameEnvironment";
            this.Size = new System.Drawing.Size(888, 628);
            this.ResumeLayout(false);

        }

        #endregion

        private UIGameInfo uiGameInfo1;
        private UIGameInfo uiGameInfo2;
        private UIGameInfo uiGameInfo3;
        private UIGameTable uiGameTable1;
        private System.Windows.Forms.Panel panel1;
    }
}
