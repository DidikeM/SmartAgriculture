using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartAgri.Business.Abstract
{
    public interface IUserManagementService
    {
        decimal GetUserBalanceById(int userId);
        void MoveCreditFromUser(int userId, decimal amount);
        void MoveCreditToUser(int userId, decimal amount);
        string WithdrawCreditFromUser(int userId, string address, decimal amount);
    }
}
