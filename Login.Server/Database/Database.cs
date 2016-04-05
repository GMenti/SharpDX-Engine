using Login.Server.Objects.Account;
using System;
using System.Collections;

namespace Login.Server
{
    static class Database
    {
        public static ArrayList accounts; 

        public static void Load()
        {
            LoadAccounts();
        }

        public static void LoadAccounts()
        {
            int startedTime = DateTime.Now.Millisecond;
            accounts = AccountDAO.findAccounts();

            int ms = DateTime.Now.Millisecond - startedTime;
            Program.frmServer.addLog("Total de " + accounts.Count + " contas carregadas. (" + ms +" ms)");
        }
    }
}
