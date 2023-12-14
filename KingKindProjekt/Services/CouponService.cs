using KingKindProjekt.Models;

namespace KingKindProjekt.Services
{
    public class CouponService
    {
        Repository<Coupon> _coupons;
        JsonFileService<Coupon> jsonFileService;
        AccountService _accountService;

        public CouponService(JsonFileService<Coupon> jsonFileService, AccountService accountService)
        {
            _accountService = accountService;
            _coupons = new Repository<Coupon>();
            this.jsonFileService = jsonFileService;
            var coupons = jsonFileService.GetJsonItems();
            if (coupons != null)
            {
                foreach (Coupon coupon in coupons)
                    CreateWithoutSaving(coupon);
            }
            else
            {
                Create(new Coupon("50-Off", 50, DateOnly.FromDateTime(DateTime.Now.AddDays(1))));
                Create(new Coupon("25-Off", 25, DateOnly.FromDateTime(DateTime.Now.AddDays(2))));
                Create(new Coupon("Off75", 75, DateOnly.FromDateTime(DateTime.Now.AddDays(3))));
            }
        }
        /// <summary>
        /// returns a number from 0 to 1, that you multiply the final price of the cart with, when checking out
        /// </summary>
        /// <returns></returns>
        public double GetCouponMultiplier(string name)
        {
            if (!_coupons.Contains(name))
                return 1d;
            Coupon coupon = _coupons.Read(name);
            DateOnly currentDate = DateOnly.FromDateTime(DateTime.Now);
            if (currentDate.CompareTo(coupon.SaleDate) > 0)
            {
                Delete(coupon.Name);
                return 1d;
            }
            return 1 - coupon.PercentOff / 100d;
        }
        public double GetCouponPercentOff(string name)
        {
            return GetCouponMultiplier(name) * 100d;
        }
        public void CreateWithoutSaving(Coupon coupon)
        {
            _coupons.Create(coupon.Name, coupon);
        }
        public void Create(Coupon coupon)
        {
            _coupons.Create(coupon.Name, coupon);
            jsonFileService.SaveJsonItems(_coupons.Items.Values);
        }
        public void Delete(string name)
        {
            _coupons.Delete(name);
            jsonFileService.SaveJsonItems(_coupons.Items.Values);
        }

        public bool IsThisCouponValid(string name)
        {
            if (!_coupons.Contains(name))
                return false;
            if (AccountService.LoggedInAccount == null)
                return false;
            return !AccountService.LoggedInAccount.UsedCoupons.Contains(name);
        }
    }
}
