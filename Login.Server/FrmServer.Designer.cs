namespace Login.Server
{
    partial class FrmServer
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.txtLog = new System.Windows.Forms.TextBox();
            this.btnOn = new System.Windows.Forms.Button();
            this.btnOff = new System.Windows.Forms.Button();
            this.lstPlayers = new System.Windows.Forms.ListBox();
            this.btnReloadAcconts = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtLog
            // 
            this.txtLog.CausesValidation = false;
            this.txtLog.Cursor = System.Windows.Forms.Cursors.Default;
            this.txtLog.HideSelection = false;
            this.txtLog.Location = new System.Drawing.Point(12, 12);
            this.txtLog.Multiline = true;
            this.txtLog.Name = "txtLog";
            this.txtLog.ReadOnly = true;
            this.txtLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtLog.ShortcutsEnabled = false;
            this.txtLog.Size = new System.Drawing.Size(317, 216);
            this.txtLog.TabIndex = 0;
            this.txtLog.TabStop = false;
            this.txtLog.WordWrap = false;
            this.txtLog.TextChanged += new System.EventHandler(this.txtLog_TextChanged);
            // 
            // btnOn
            // 
            this.btnOn.Location = new System.Drawing.Point(12, 236);
            this.btnOn.Name = "btnOn";
            this.btnOn.Size = new System.Drawing.Size(114, 24);
            this.btnOn.TabIndex = 1;
            this.btnOn.Text = "Ligar";
            this.btnOn.UseVisualStyleBackColor = true;
            this.btnOn.Click += new System.EventHandler(this.btnOn_Click);
            // 
            // btnOff
            // 
            this.btnOff.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnOff.Location = new System.Drawing.Point(215, 236);
            this.btnOff.Name = "btnOff";
            this.btnOff.Size = new System.Drawing.Size(114, 24);
            this.btnOff.TabIndex = 2;
            this.btnOff.Text = "Desligar";
            this.btnOff.UseVisualStyleBackColor = true;
            this.btnOff.Click += new System.EventHandler(this.btnOff_click);
            // 
            // lstPlayers
            // 
            this.lstPlayers.FormattingEnabled = true;
            this.lstPlayers.Location = new System.Drawing.Point(335, 12);
            this.lstPlayers.Name = "lstPlayers";
            this.lstPlayers.Size = new System.Drawing.Size(144, 212);
            this.lstPlayers.TabIndex = 3;
            this.lstPlayers.SelectedIndexChanged += new System.EventHandler(this.lstPlayers_SelectedIndexChanged);
            // 
            // btnReloadAcconts
            // 
            this.btnReloadAcconts.Location = new System.Drawing.Point(529, 12);
            this.btnReloadAcconts.Name = "btnReloadAcconts";
            this.btnReloadAcconts.Size = new System.Drawing.Size(170, 23);
            this.btnReloadAcconts.TabIndex = 4;
            this.btnReloadAcconts.Text = "Recarregar Accounts";
            this.btnReloadAcconts.UseVisualStyleBackColor = true;
            this.btnReloadAcconts.Click += new System.EventHandler(this.btnReloadAcconts_Click);
            // 
            // FrmServer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(747, 272);
            this.Controls.Add(this.btnReloadAcconts);
            this.Controls.Add(this.lstPlayers);
            this.Controls.Add(this.btnOff);
            this.Controls.Add(this.btnOn);
            this.Controls.Add(this.txtLog);
            this.Name = "FrmServer";
            this.Text = "Login Server";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnOn;
        private System.Windows.Forms.Button btnOff;
        public System.Windows.Forms.TextBox txtLog;
        public System.Windows.Forms.ListBox lstPlayers;
        private System.Windows.Forms.Button btnReloadAcconts;
    }
}

