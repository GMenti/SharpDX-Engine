using MySql.Data.MySqlClient;
using Network.Library.Packets;
using Newtonsoft.Json;
using System.Collections;

namespace Login.Server.Objects.Account
{
    static class AccountDAO
    {
        public static void addAccount(AccountData data)
        {
            Account newAcc = new Account() {
                login = data.login,
                password = data.password
            };

            MySqlCommand query = new MySqlCommand("INSERT INTO player (data) VALUES (@data)");
            query.Parameters.AddWithValue("@data", JsonConvert.SerializeObject(newAcc));
            MySQL.Save(query);

            Database.accounts.Add(newAcc);
        }

        public static ArrayList findAccounts()
        {
            MySqlDataReader result = MySQL.Find("SELECT * FROM player");

            ArrayList accounts = new ArrayList();
            while (result.Read()) {
                Account account = JsonConvert.DeserializeObject<Account>(result.GetString("data"));
                accounts.Add(account);
            }

            MySQL.Close();

            return accounts;
        }

    }
}
