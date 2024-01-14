using SmartAgri.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartAgri.Business.Abstract
{
    public interface IUserManagementService
    {
        List<AdvertSell> GetActiveSellAdvertByUserId(int userId);
        List<AdvertBuy> GetActiveBuyAdvertByUserId(int userId);
        List<AdvertSell> GetPastSellAdvertByUserId(int userId);
        List<AdvertBuy> GetPastBuyAdvertByUserId(int userId);
        decimal GetUserBalanceById(int userId);
        void MoveCreditFromUser(int userId, decimal amount);
        void MoveCreditToUser(int userId, decimal amount);
        string WithdrawCreditFromUser(int userId, string address, decimal amount);
        User GetUser(int userId);
        void UpdateUser(User user);
        List<AdvertBuy> GetRecentBuyAdverts();
        List<AdvertSell> GetRecentSellAdverts();
        decimal GetSystemBalance();
        int GetActiveAdvertBuyCount();
        int GetActiveAdvertSellCount();
        int GetTransactionsCount();
        int GetUserActiveAdvertBuyCountById(int userId);
        int GetUserActiveAdvertSellCountById(int userId);
        int GetUserTransactionsCountById(int userId);
        List<User> GetAllUser();
        List<Tuple<Product, int>> GetAllCompletedAdvertCountAndProduct();
        void AddGuestMessage(GuestMessage message);
        List<GuestMessage> GetGuestMessages();
        GuestMessage GetGuestMessageById(int guestMessageId);
    }
}
