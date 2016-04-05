using System;
using System.Windows.Forms;

namespace Login.Server
{
    static class Program
    {

        public static FrmServer frmServer;

        [STAThread]
        static void Main()
        {  
            using (frmServer = new FrmServer()) {
                Application.EnableVisualStyles();
                Application.Run(frmServer);
            }
        }
    }
}
