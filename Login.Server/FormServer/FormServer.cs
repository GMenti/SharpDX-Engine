using System;
using System.Windows.Forms;

namespace Login.Server
{
    public partial class FormServer : Form
    {
        
        public FormServer()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //TODO
        }

        private void btnOff_click(object sender, EventArgs e)
        {
            this.Shutdown();
        }

        private void btnOn_Click(object sender, EventArgs e)
        {
            this.Start();
        }

    }
}
