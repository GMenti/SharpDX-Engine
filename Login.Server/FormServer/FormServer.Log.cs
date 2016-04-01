using System;
using System.Windows.Forms;

namespace Login.Server
{
    public partial class FormServer : Form
    {
        private int lineCount = 1;

        private void addLog(string text)
        {
            txtLog.AppendText("[" + this.lineCount + "] " + text + Environment.NewLine);
            this.lineCount++;
        }
    }
}
