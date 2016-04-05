using MySql.Data.MySqlClient;
using System.Collections;

namespace Login.Server.Objects.Account
{
    static class AccountDAO
    {
        public static void addAccount(Account newAccount)
        {
            //TODO
        }

        public static ArrayList findAccounts()
        {
            MySqlDataReader result = MySQL.Find("SELECT * FROM accounts");

            ArrayList accounts = new ArrayList();
            while (result.Read()) {
                Account account = new Account {
                    id = result.GetInt32("id"),
                    login = result.GetString("login"),
                    password = result.GetString("password")
                };
                accounts.Add(account);
            }

            return accounts;
        }
    }
}
