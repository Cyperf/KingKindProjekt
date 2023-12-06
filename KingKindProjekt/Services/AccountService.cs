using KingKindProjekt.Models;
using System.Diagnostics;

namespace KingKindProjekt.Services
{
    public class AccountService
    {
        Repository<Account> accounts;

        public AccountService()
        {
            accounts = new Repository<Account>();
            Create(new Account("name", "email@gmail.com", "password", PrivateOrCorporation.Private, AccountType.Customer, "cvr", "AAA vej, 4000 Roskilde", "Danmark", "+45 10 02 24 90", false));
            Create(new Account("name2", "email2@gmail.com", "pass", PrivateOrCorporation.Private, AccountType.Customer, "cvr", "BBB vej, 4000 Roskilde", "Danmark", "+45 15 22 42 09", false));
        }

        public Account LoggedInAccount { get; set; } = null;

        public bool IsLoggedIn() { return LoggedInAccount != null; }
        public bool TryLogin (string Email, string password)
        {
            //Debug.WriteLine(Email + " : " + password);
            Account temp = accounts.Read(Email);
            if (temp == null || temp.Password != password)
                return false;
            LoggedInAccount = temp;
            return true;
        }

        public void Create(Account account)
        {
            accounts.Create(account.EMail, account);
        }
    }
}
