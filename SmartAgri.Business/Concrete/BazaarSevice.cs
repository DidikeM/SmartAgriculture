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
        private readonly IUserDal _userDal;
        private readonly IAgriCoinApi _agriCoinApi;
        private readonly ITransactionDal _transactionDal;


        public BazaarSevice(IProductDal productdal,
                            IAdvertBuyDal advertBuyDal,
                            IAdvertSellDal advertSellDal,
                            IPredictPrice predictPrice,
                            IUserDal userDal,
                            IAgriCoinApi agriCoinApi,
                            ITransactionDal transactionDal)
        {
            _productdal = productdal;
            _advertBuyDal = advertBuyDal;
            _advertSellDal = advertSellDal;
            _predictPrice = predictPrice;
            _userDal = userDal;
            _agriCoinApi = agriCoinApi;
            _transactionDal = transactionDal;
        }

        public void AddBuyAdvert(AdvertBuy advert)
        {
            var user = _userDal.Get(u => u.Id == advert.UserId);
            user.LockedBalance -= advert.UnitPrice * advert.Quantity;
            _userDal.Update(user);
            _advertBuyDal.Add(advert);
        }

        public void AddSellAdvert(AdvertSell advert)
        {
            _advertSellDal.Add(advert);
        }

        public void BuySellAdvert(int userId, int selAdvertId)
        {
            var user = _userDal.Get(u => u.Id == userId);
            var balance = _agriCoinApi.GetBalance(user.CoinAccountId);
            var advertSell = _advertSellDal.GetWithUser(s => s.Id == selAdvertId);
            if (balance < advertSell.UnitPrice * advertSell.Quantity)
            {
                throw new Exception("Yeterli bakiyeniz bulunmamaktadır.");
            }

            if (!_agriCoinApi.MoveAccountToAccount(user.CoinAccountId, advertSell.User.CoinAccountId, advertSell.UnitPrice * advertSell.Quantity))
            {
                throw new Exception("Transfer işlemi sırasında bir hata ile karşılaşıldı lütfen daha sonra tekrar deneyin.");
            }

            var advertBuy = new AdvertBuy
            {
                ProductId = advertSell.ProductId,
                Quantity = advertSell.Quantity,
                UnitPrice = advertSell.UnitPrice,
                UserId = userId,
                StatusId = (int)AdvertStatusEnum.complated,
                CreatedAt = DateTime.Now,
            };
            _advertBuyDal.Add(advertBuy);

            advertSell.StatusId = (int)AdvertStatusEnum.complated;
            _advertSellDal.Update(advertSell);

            var transaction = new Transaction
            {
                BuyAdvertId = advertBuy.Id,
                SellAdvertId = selAdvertId,
                CreatedAt = DateTime.Now
            };
            _transactionDal.Add(transaction);
        }

        public void SellBuyAdvert(int userId, int buyAdvertId)
        {
            var user = _userDal.Get(u => u.Id == userId);
            var advertBuy = _advertBuyDal.GetWithUser(s => s.Id == buyAdvertId);
            var balance = _agriCoinApi.GetBalance(advertBuy.User.CoinAccountId);
            if (balance < advertBuy.UnitPrice * advertBuy.Quantity)
            {
                throw new Exception("Teknik bir hata ile karşılaşıldı lütfen daha sonra tekrar deneyin.");
            }

            if (!_agriCoinApi.MoveAccountToAccount(advertBuy.User.CoinAccountId, user.CoinAccountId, advertBuy.UnitPrice * advertBuy.Quantity))
            {
                throw new Exception("Transfer işlemi sırasında bir hata ile karşılaşıldı lütfen daha sonra tekrar deneyin.");
            }

            advertBuy.User.LockedBalance -= advertBuy.UnitPrice * advertBuy.Quantity;
            _userDal.Update(advertBuy.User);

            var advertSell = new AdvertSell
            {
                ProductId = advertBuy.ProductId,
                Quantity = advertBuy.Quantity,
                UnitPrice = advertBuy.UnitPrice,
                UserId = userId,
                StatusId = (int)AdvertStatusEnum.complated,
                CreatedAt = DateTime.Now,
            };
            _advertSellDal.Add(advertSell);

            advertBuy.StatusId = (int)AdvertStatusEnum.complated;
            _advertBuyDal.Update(advertBuy);

            var transaction = new Transaction
            {
                BuyAdvertId = advertBuy.Id,
                SellAdvertId = buyAdvertId,
                CreatedAt = DateTime.Now
            };
            _transactionDal.Add(transaction);
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
