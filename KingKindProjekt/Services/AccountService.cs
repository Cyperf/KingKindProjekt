using KingKindProjekt.Models;

// Lavet af Jeppe

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
                Create(new Account("user", "user@user.user", "users", PrivateOrCorporation.Private, AccountType.Customer, "cvr", "AAA vej, 4000 Roskilde", "Danmark", "45 10022490", false, null, null));
                Create(new Account("Admin", "admin@admin.admin", "admin", PrivateOrCorporation.Private, AccountType.Admin, "cvr", "BBB vej, 4000 Roskilde", "Danmark", "45 15224209", false, null, null));
            }
        }

        public AccountService() { }

        public static Account LoggedInAccount { get; set; } = null;

        public bool IsLoggedIn() { return LoggedInAccount != null; }
        public bool TryLogin(string Email, string password)
        {
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

        public Account Read(string Email)
        {
            return accounts.Read(Email);
        }

        public void Update(Account account)
        {
            accounts.Update(account.EMail, account);
            Save();
        }

        public void Delete(Account account)
        {
            accounts.Delete(account.EMail);
            Save();
        }

        public static string checkAccountState()
        {
            if (AccountService.LoggedInAccount != null)
            {
                if (AccountService.LoggedInAccount._AccountType == AccountType.Admin)
                { return "Admin"; }
                else return "User";

            }
            else return "Login";
        }

        public static void LogOut()
        {
            LoggedInAccount = null;

        }
        public void Save()
        {
            jsonFileService.SaveJsonItems(accounts.Items.Values);
        }
    }
}
