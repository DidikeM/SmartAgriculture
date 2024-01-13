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
        private readonly ITransactionDal _transactionDal;
        public UserManagementService(IAgriCoinApi agriCoinApi, IUserDal userDal, IAdvertBuyDal advertBuyDal, IAdvertSellDal advertSellDal, ITransactionDal transactionDal)
        {
            _agriCoinApi = agriCoinApi;
            _userDal = userDal;
            _advertBuyDal = advertBuyDal;
            _advertSellDal = advertSellDal;
            _transactionDal = transactionDal;
        }

        public int GetActiveAdvertBuyCount()
        {
            return _advertBuyDal.GetCount(a => a.StatusId == (int)AdvertStatusEnum.Active);
        }

        public int GetActiveAdvertSellCount()
        {
            return _advertSellDal.GetCount(a => a.StatusId == (int)AdvertStatusEnum.Active);
        }

        public List<AdvertBuy> GetActiveBuyAdvertByUserId(int userId)
        {
            return _advertBuyDal.GetAllWithProduct(a => a.UserId == userId && a.StatusId == (int)AdvertStatusEnum.Active);
        }

        public List<AdvertSell> GetActiveSellAdvertByUserId(int userId)
        {
            return _advertSellDal.GetAllWithProduct(a => a.UserId == userId && a.StatusId == (int)AdvertStatusEnum.Active);
        }

        public List<User> GetAllUser()
        {
            return _userDal.GetAll(u => u.RoleId == (int)UserRoleEnum.User);
        }

        public List<AdvertBuy> GetPastBuyAdvertByUserId(int userId)
        {
            return _advertBuyDal.GetAllWithProduct(a => a.UserId == userId && a.StatusId != (int)AdvertStatusEnum.Active);
        }

        public List<AdvertSell> GetPastSellAdvertByUserId(int userId)
        {
            return _advertSellDal.GetAllWithProduct(a => a.UserId == userId && a.StatusId != (int)AdvertStatusEnum.Active);
        }

        public List<AdvertBuy> GetRecentBuyAdverts()
        {
            return _advertBuyDal.GetAllRecent(10);
        }

        public List<AdvertSell> GetRecentSellAdverts()
        {
            return _advertSellDal.GetAllRecent(10);
        }

        public decimal GetSystemBalance()
        {
            return _agriCoinApi.GetSystemBalance();
        }

        public int GetTransactionsCount()
        {
            return _transactionDal.GetCount();
        }

        public User GetUser(int userId)
        {
            return _userDal.Get(u => u.Id == userId);
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

        public void UpdateUser(User user)
        {
            _userDal.Update(user);
        }

        public string WithdrawCreditFromUser(int userId, string address, decimal amount)
        {
            return _agriCoinApi.Withdraw(_userDal.Get(u => u.Id == userId).CoinAccountId, address, amount);
        }
    }
}
