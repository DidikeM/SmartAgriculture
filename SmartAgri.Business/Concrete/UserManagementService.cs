using SmartAgri.Business.Abstract;
using SmartAgri.DataAccess.Abstract;
using SmartAgri.Entities.Concrete;
using SmartAgri.Entities.Enums;
using SmartAgri.ServiceAPI.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartAgri.Business.Concrete
{
    public class UserManagementService : IUserManagementService
    {
        private readonly IAgriCoinApi _agriCoinApi;
        private readonly IUserDal _userDal;
        private readonly IAdvertBuyDal _advertBuyDal;
        private readonly IAdvertSellDal _advertSellDal;

        public UserManagementService(IAgriCoinApi agriCoinApi, IUserDal userDal, IAdvertBuyDal advertBuyDal, IAdvertSellDal advertSellDal)
        {
            _agriCoinApi = agriCoinApi;
            _userDal = userDal;
            _advertBuyDal = advertBuyDal;
            _advertSellDal = advertSellDal;
        }

        public List<AdvertBuy> GetActiveBuyAdvertByUserId(int userId)
        {
            return _advertBuyDal.GetAllWithProduct(a => a.UserId == userId && a.StatusId == (int)AdvertStatusEnum.Active);
        }

        public List<AdvertSell> GetActiveSellAdvertByUserId(int userId)
        {
            return _advertSellDal.GetAllWithProduct(a => a.UserId == userId && a.StatusId == (int)AdvertStatusEnum.Active);
        }

        public List<AdvertBuy> GetPastBuyAdvertByUserId(int userId)
        {
            return _advertBuyDal.GetAllWithProduct(a => a.UserId == userId && a.StatusId != (int)AdvertStatusEnum.Active);
        }

        public List<AdvertSell> GetPastSellAdvertByUserId(int userId)
        {
            return _advertSellDal.GetAllWithProduct(a => a.UserId == userId && a.StatusId != (int)AdvertStatusEnum.Active);
        }

        public decimal GetUserBalanceById(int userId)
        {
            return _agriCoinApi.GetBalance(_userDal.Get(u => u.Id == userId).CoinAccountId);
        }

        public void MoveCreditFromUser(int userId, decimal amount)
        {
            if (!_agriCoinApi.MoveAccountToMain(_userDal.Get(u => u.Id == userId).CoinAccountId, amount))
            {
                throw new Exception("Transfer işlemi sırasında bir hata ile karşılaşıldı.");
            }
        }

        public void MoveCreditToUser(int userId, decimal amount)
        {
            if (!_agriCoinApi.MoveMainToAccount(_userDal.Get(u => u.Id == userId).CoinAccountId, amount))
            {
                throw new Exception("Transfer işlemi sırasında bir hata ile karşılaşıldı.");
            }
        }

        public string WithdrawCreditFromUser(int userId, string address, decimal amount)
        {
            return _agriCoinApi.Withdraw(_userDal.Get(u => u.Id == userId).CoinAccountId, address, amount);
        }
    }
}
