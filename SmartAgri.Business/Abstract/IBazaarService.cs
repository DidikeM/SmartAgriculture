using SmartAgri.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartAgri.Business.Abstract
{
    public interface IBazaarService
    {
        void AddBuyAdvert(AdvertBuy advert);
        void AddSellAdvert(AdvertSell advert);
        void BuySellAdvert(int userId, int sellAdvertId);
        List<Product> GetAllProducts();
        List<AdvertBuy> GetActiveBuyAdvertsByProductId(int id);
        Product GetProductById(int id);
        decimal GetProductCurrentPrice(int id);
        decimal GetProductExpectedPrice(int id);
        List<decimal> GetProductOldPrices(int id);
        List<AdvertSell> GetActiveSellAdvertsByProductId(int id);
        void SellBuyAdvert(int userId, int buyAdvertId);
    }
}
