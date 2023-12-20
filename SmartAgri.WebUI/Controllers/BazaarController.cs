using Microsoft.AspNetCore.Mvc;
using SmartAgri.Business.Abstract;
using SmartAgri.Entities.Concrete;
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
        public IActionResult GetProducts()
        {
            GetProductsResponseDto response = new();
            List<Product> products = _bazaarService.GetAllProducts();

            response.Products = products.Select(p => new ProductDto(p)).ToList();

            foreach(var productDto in response.Products)
            {
                productDto.CurrentPrice = _bazaarService.GetProductCurrentPrice(productDto.Id);
                productDto.ExpectedPrice = _bazaarService.GetProductExpectedPrice(productDto.Id);
            }

            return Json(response);
        }

        public IActionResult GetProduct(int id)
        {
            GetProductResponseDto response = new()
            {
                Product = new ProductDto(_bazaarService.GetProductById(id))
                {
                    CurrentPrice = _bazaarService.GetProductCurrentPrice(id)
                }
            };

            return Json(response);
        }

        public IActionResult GetBuyAdvertsByProduct(int id)
        {
            GetBuyAdvertsResponseDto response = new()
            {
                BuyAdverts = _bazaarService.GetBuyAdvertsByProductId(id).Select(b => new AdvertDto(b)).ToList()
            };
            return Json(response);
        }

        public IActionResult GetSellAdvertsByProduct(int id)
        {
            GetSellAdvertsResponseDto response = new()
            {
                SellAdverts = _bazaarService.GetSellAdvertsByProductId(id).Select(s => new AdvertDto(s)).ToList()
            };
            return Json(response);
        }

        public IActionResult AddBuyAdvert()
        {
            return View();
        }

        public IActionResult AddSellAdvert()
        {
            return View();
        }

    }
}
