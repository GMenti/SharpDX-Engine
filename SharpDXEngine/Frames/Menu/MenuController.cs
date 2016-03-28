using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpDXEngine.Frames.Menu
{
    class MenuController
    {
        public void Login(string user, string password)
        {
            System.Windows.Forms.MessageBox.Show(
                "Login: " + user +
                "\nSenha: " + password
            );
        }
    }
}
