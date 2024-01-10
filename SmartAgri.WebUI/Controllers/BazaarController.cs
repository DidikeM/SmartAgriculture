using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SmartAgri.Business.Abstract;
using SmartAgri.Business.Concrete;
using SmartAgri.Entities.Concrete;
using SmartAgri.Entities.Enums;
using SmartAgri.WebUI.DTOs;

namespace SmartAgri.WebUI.Controllers
{
    public class BazaarController : Controller
    {
        private readonly IBazaarService _bazaarService;
        public BazaarController(IBazaarService bazaarService)
        {
            _bazaarService = bazaarService;
        }

        [HttpGet]
        public IActionResult GetProducts()
        {
            GetProductsResponseDto response = new();
            List<Product> products = _bazaarService.GetAllProducts();

            response.Products = products.Select(p => new ProductDto(p)).ToList();

            foreach (var productDto in response.Products)
            {
                productDto.CurrentPrice = _bazaarService.GetProductCurrentPrice(productDto.Id);
                productDto.ExpectedPrice = _bazaarService.GetProductExpectedPrice(productDto.Id);
                productDto.OldPrices = _bazaarService.GetProductOldPrices(productDto.Id);
            }

            return Json(response.Products);
        }

        [HttpGet]
        public IActionResult GetProduct(int id)
        {
            GetProductResponseDto response = new()
            {
                Product = new ProductDto(_bazaarService.GetProductById(id))
                {
                    CurrentPrice = _bazaarService.GetProductCurrentPrice(id),
                    ExpectedPrice = _bazaarService.GetProductExpectedPrice(id),
                }
            };

            return Json(response.Product);
        }

        [HttpGet]
        public IActionResult GetBuyAdvertsByProduct(int id)
        {
            GetBuyAdvertsResponseDto response = new()
            {
                BuyAdverts = _bazaarService.GetActiveBuyAdvertsByProductId(id).Select(b => new AdvertDto(b)).ToList()
            };
            return Json(response.BuyAdverts);
        }

        [HttpGet]
        public IActionResult GetSellAdvertsByProduct(int id)
        {
            GetSellAdvertsResponseDto response = new()
            {
                SellAdverts = _bazaarService.GetActiveSellAdvertsByProductId(id).Select(s => new AdvertDto(s)).ToList()
            };
            return Json(response.SellAdverts);
        }

        [HttpPost, Authorize]
        public void AddBuyAdvert([FromBody] AddBuyAdvertDto addBuyAdvertDto)
        {
            AdvertBuy advert = new()
            {
                ProductId = addBuyAdvertDto.ProductId,
                UserId = GetClaim.GetUserId(User),
                UnitPrice = addBuyAdvertDto.UnitPrice,
                Quantity = addBuyAdvertDto.Quantity,
                CreatedAt = DateTime.Now,
                StatusId = (int)AdvertStatusEnum.Active
            };
            _bazaarService.AddBuyAdvert(advert);
        }

        [HttpPost, Authorize]
        public void AddSellAdvert([FromBody] AddSellAdvertDto addSellAdvertDto)
        {
            AdvertSell advert = new()
            {
                ProductId = addSellAdvertDto.ProductId,
                UserId = GetClaim.GetUserId(User),
                UnitPrice = addSellAdvertDto.UnitPrice,
                Quantity = addSellAdvertDto.Quantity,
                CreatedAt = DateTime.Now,
                StatusId = (int)AdvertStatusEnum.Active
            };
            _bazaarService.AddSellAdvert(advert);
        }

        [HttpPost, Authorize]
        public IActionResult BuySellAdvert([FromBody] int sellAdvertId)
        {
            try
            {
                _bazaarService.BuySellAdvert(GetClaim.GetUserId(User), sellAdvertId);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
            return Ok();
        }

        [HttpPost, Authorize]
        public IActionResult SellBuyAdvert([FromBody] int buyAdvertId)
        {
            try
            {
                _bazaarService.SellBuyAdvert(GetClaim.GetUserId(User), buyAdvertId);
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
            return Ok();
        }
    }
}
