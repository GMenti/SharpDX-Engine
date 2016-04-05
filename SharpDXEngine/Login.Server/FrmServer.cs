using Login.Server;
using System;
using System.Windows.Forms;

namespace Login.Server
{
    public partial class FrmServer : Form
    {
        
        public FrmServer()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Database.Load();
        }

        private void btnOff_click(object sender, EventArgs e)
        {
            Network.Shutdown();
        }

        private void btnOn_Click(object sender, EventArgs e)
        {
            Network.Start();
        }

        private void txtLog_TextChanged(object sender, EventArgs e)
        {

        }

        private int lineCount = 1;
        public void addLog(string text)
        {
            txtLog.AppendText("[" + this.lineCount + "] " + text + Environment.NewLine);
            this.lineCount++;
        }

        private void lstPlayers_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnReloadAcconts_Click(object sender, EventArgs e)
        {
            Database.LoadAccounts();
        }
    }
}
