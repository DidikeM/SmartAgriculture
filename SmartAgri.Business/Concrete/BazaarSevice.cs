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
    public class BazaarSevice : IBazaarService
    {
        private readonly IProductDal _productdal;
        private readonly IAdvertBuyDal _advertBuyDal;
        private readonly IAdvertSellDal _advertSellDal;
        private readonly IPredictPrice _predictPrice;


        public BazaarSevice(IProductDal productdal, IAdvertBuyDal advertBuyDal, IAdvertSellDal advertSellDal, IPredictPrice predictPrice)
        {
            _productdal = productdal;
            _advertBuyDal = advertBuyDal;
            _advertSellDal = advertSellDal;
            _predictPrice = predictPrice;
        }

        public List<Product> GetAllProducts()
        {
            return _productdal.GetAll();
        }

        public List<AdvertBuy> GetBuyAdvertsByProductId(int id)
        {
            return _advertBuyDal.GetAll(a => a.ProductId == id && a.StatusId == (int)AdvertStatusEnum.Active);
        }

        public Product GetProductById(int id)
        {
            return _productdal.Get(p => p.Id == id);
        }

        public decimal GetProductCurrentPrice(int id)
        {
            return _productdal.GetProductCurrentPrice(id);
        }

        public decimal GetProductExpectedPrice(int id)
        {
            return _predictPrice.Predict((ProductEnum)id).Result;
        }

        public List<decimal> GetProductOldPrices(int id)
        {
            return _productdal.GetProductOldPrices(id);
        }

        public List<AdvertSell> GetSellAdvertsByProductId(int id)
        {
            return _advertSellDal.GetAll(a => a.ProductId == id && a.StatusId == (int)AdvertStatusEnum.Active);
        }
    }
}
