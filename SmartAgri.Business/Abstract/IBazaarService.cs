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
        List<Product> GetAllProducts();
        List<AdvertBuy> GetBuyAdvertsByProductId(int id);
        Product GetProductById(int id);
        decimal GetProductCurrentPrice(int id);
        decimal GetProductExpectedPrice(int id);
        List<AdvertSell> GetSellAdvertsByProductId(int id);
    }
}
