using SmartAgri.Business.Abstract;
using SmartAgri.DataAccess.Abstract;
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

        public UserManagementService(IAgriCoinApi agriCoinApi, IUserDal userDal)
        {
            _agriCoinApi = agriCoinApi;
            _userDal = userDal;
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
