using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace KingKindProjekt.Models
{
    public enum PrivateOrCorporation
    {
        Private, Corporation
    }
    public enum AccountType
    {
        Customer, Worker, Admin
    }

    public class Account
    {
        [BindProperty]
        public string Name { get; set; }
        [BindProperty]
        [Display(Name = "E-Mail")]
        public string EMail { get; set; }
        [BindProperty]
        public string Password { get; set; }
        [BindProperty]
        public PrivateOrCorporation _PrivateOrCorporation { get; set; }
        [BindProperty]
        public AccountType _AccountType { get; set; }
        [BindProperty]
        public string CVR { get; set; }
        [BindProperty]
        public string Address { get; set; }
        [BindProperty]
        public string Country { get; set; }
        [BindProperty]
        public string PhoneNumber { get; set; }
        [BindProperty]
        public bool WantsNewsLetter { get; set; }
        [BindProperty]
        public List<string>? Receipts { get; set; }
        [BindProperty]
        public List<string>? UsedCoupons { get; set; }


        public Account()
        { Receipts = new List<string>(); UsedCoupons = new List<string>(); }
        public Account(string name, string email, string password, PrivateOrCorporation poc, AccountType at, string cvr, string address, string country, string phoneNumber, bool wantsNewsLetter, List<string>? receipts, List<string>? usedCoupons)
        {
            Name = name;
            EMail = email;
            Password = password;
            _PrivateOrCorporation = poc;
            _AccountType = at;
            CVR = cvr;
            Address = address;
            Country = country;
            PhoneNumber = phoneNumber;
            WantsNewsLetter = wantsNewsLetter;
            Receipts = receipts;
            if (Receipts == null) { Receipts = new List<string>(); }
            UsedCoupons = usedCoupons;
            if (UsedCoupons == null) { UsedCoupons = new List<string>(); }
        }

        public override string ToString()
        {
            string temp = "";
            foreach (string str in Receipts)
            {
                temp = temp + str;

            }
            return temp;
        }

    }
}
