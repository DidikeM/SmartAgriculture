using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartAgri.ServiceAPI.Abstract
{
    public interface IAgriCoinApi
    {
        string CreateAccount(Guid accountName);

        bool MoveMainToAccount(Guid accountName, decimal amount);

        bool MoveAccountToMain(Guid accountName, decimal amount);

        bool MoveAccountToAccount(Guid fromAccountName, Guid toAccountName, decimal amount);

        string Withdraw(Guid accountName, string address, decimal amount);

        decimal GetBalance(Guid accountName);
        decimal GetSystemBalance();
    }
}
