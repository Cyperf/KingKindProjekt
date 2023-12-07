using KingKindProjekt.Models;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace KingKindProjekt.Services
{
    public class AccountService
    {
        Repository<Account> accounts;
        JsonFileService<Account> jsonFileService;

        public AccountService(JsonFileService<Account> jsonFileService)
        {
            this.jsonFileService = jsonFileService;
            accounts = new Repository<Account>();
            var savedAccounts = jsonFileService.GetJsonItems();
            if (savedAccounts != null)
            {
                foreach (var account in savedAccounts)
                {
                    CreateWithoutSaving(account);
                }
            }
            else // dummy data
            {
            Create(new Account("name", "email@gmail.com", "password", PrivateOrCorporation.Private, AccountType.Customer, "cvr", "AAA vej, 4000 Roskilde", "Danmark", "+45 10 02 24 90", false));
            Create(new Account("name2", "email2@gmail.com", "pass", PrivateOrCorporation.Private, AccountType.Customer, "cvr", "BBB vej, 4000 Roskilde", "Danmark", "+45 15 22 42 09", false));
            }
        }

        public AccountService() { }

        public static Account LoggedInAccount { get; set; } = null;

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
        public void CreateWithoutSaving(Account account)
        {
            accounts.Create(account.EMail, account);
        }
        public void Create(Account account)
        {
            accounts.Create(account.EMail, account);
            jsonFileService.SaveJsonItems(accounts.Items.Values);
        }

        public static string checkAccountState()
        {
            if (AccountService.LoggedInAccount != null)
            {
                return "Admin";
            }
            else return "Login";
        }
    }
}
