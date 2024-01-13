using BitcoinLib.Services;
using BitcoinLib.Services.Coins.Base;
using SmartAgri.ServiceAPI.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartAgri.ServiceAPI.Concrete
{
    public class AgriCoinApi : IAgriCoinApi
    {
        private readonly ICoinService _coinService;
        public AgriCoinApi(ICoinService coinService)
        {
            _coinService = coinService;
        }

        public string CreateAccount(Guid accountName)
        {
            return _coinService.GetNewAddress(accountName.ToString());
        }

        public bool MoveMainToAccount(Guid accountName, decimal amount)
        {
            return _coinService.Move("", accountName.ToString(), amount);
        }

        public bool MoveAccountToMain(Guid accountName, decimal amount)
        {
            return _coinService.Move(accountName.ToString(), "", amount);
        }

        public bool MoveAccountToAccount(Guid fromAccountName, Guid toAccountName, decimal amount)
        {
            return _coinService.Move(fromAccountName.ToString(), toAccountName.ToString(), amount);
        }

        public string Withdraw(Guid accountName, string address, decimal amount)
        {
            return _coinService.SendFrom(accountName.ToString(), address, amount);
        }

        public decimal GetBalance(Guid accountName)
        {
            return _coinService.GetBalance(accountName.ToString());
        }

        public decimal GetSystemBalance()
        {
            return _coinService.GetBalance("");
        }
    }
}