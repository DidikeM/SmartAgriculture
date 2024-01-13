using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SmartAgri.Business.Abstract;
using SmartAgri.Entities.Concrete;
using SmartAgri.Entities.Enums;
using SmartAgri.WebUI.DTOs;

namespace SmartAgri.WebUI.Controllers
{
    [Authorize]
    public class UserManagementController : Controller
    {
        private readonly IUserManagementService _userManagementService;
        public UserManagementController(IUserManagementService userManagementService)
        {
            _userManagementService = userManagementService;
        }

        [HttpGet]
        public IActionResult GetBalanceForUser()
        {
            try
            {
                return Json(_userManagementService.GetUserBalanceById(GetClaim.GetUserId(User)));
            }
            catch (Exception)
            {
                return BadRequest("Coin Service'e ulaşılamadı.");
            }
        }

        [HttpPost]
        public IActionResult BuyCredit([FromBody] decimal amount)
        {
            try
            {
                _userManagementService.MoveCreditToUser(GetClaim.GetUserId(User), amount);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

            return Ok();
        }

        [HttpPost]
        public IActionResult SellCredit([FromBody] decimal amount)
        {
            try
            {
                _userManagementService.MoveCreditFromUser(GetClaim.GetUserId(User), amount);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

            return Ok();
        }

        [HttpPost]
        public IActionResult WithdrawCredit([FromBody] WithdrawDto withdrawDto)
        {
            string result;

            try
            {
                result = _userManagementService.WithdrawCreditFromUser(GetClaim.GetUserId(User), withdrawDto.address, withdrawDto.amount);
            }
            catch (Exception)
            {
                return BadRequest();
            }

            return Ok(Json(result));
        }

        [HttpGet]
        public IActionResult GetActiveSellAdvertsForUser()
        {
            var advertList = _userManagementService.GetActiveSellAdvertByUserId(GetClaim.GetUserId(User)).Select(p => new UserManagementAdvertDto
            {
                Name = p.Product.Name,
                UnitPrice = p.UnitPrice,
                Quantity = p.Quantity,
                Date = p.CreatedAt,
            });

            return Json(advertList);
        }


        [HttpGet]
        public IActionResult GetActiveBuyAdvertsForUser()
        {
            var advertList = _userManagementService.GetActiveBuyAdvertByUserId(GetClaim.GetUserId(User)).Select(p => new UserManagementAdvertDto
            {
                Name = p.Product.Name,
                UnitPrice = p.UnitPrice,
                Quantity = p.Quantity,
                Date = p.CreatedAt,
            });

            return Json(advertList);
        }


        [HttpGet]
        public IActionResult GetPastSellAdvertsForUser()
        {
            var advertList = _userManagementService.GetPastSellAdvertByUserId(GetClaim.GetUserId(User)).Select(p => new UserManagementAdvertDto
            {
                Name = p.Product.Name,
                UnitPrice = p.UnitPrice,
                Quantity = p.Quantity,
                Date = p.CreatedAt,
            });

            return Json(advertList);
        }


        [HttpGet]
        public IActionResult GetPastBuyAdvertsForUser()
        {
            var advertList = _userManagementService.GetPastBuyAdvertByUserId(GetClaim.GetUserId(User)).Select(p => new UserManagementAdvertDto
            {
                Name = p.Product.Name,
                UnitPrice = p.UnitPrice,
                Quantity = p.Quantity,
                Date = p.CreatedAt,
            });

            return Json(advertList);
        }

        [HttpGet, Authorize]
        public IActionResult GetUserInfo()
        {
            return Json(_userManagementService.GetUser(GetClaim.GetUserId(User)));
        }

        [HttpPost, Authorize]
        public IActionResult PostUserInfo([FromBody] User user)
        {
            try
            {
                var _user = _userManagementService.GetUser(user.Id);
                _user.Password = user.Password;
                _user.ExternalCoinAddress = user.ExternalCoinAddress;

                _userManagementService.UpdateUser(_user);
            }
            catch (Exception)
            {
                return BadRequest();
            }

            return Ok();
        }

        [HttpGet, Authorize]
        public IActionResult GetRecentBuyAdvertForAdmin()
        {
            List<AdvertBuy> adverts = _userManagementService.GetRecentBuyAdverts();

            List<UserManagementAdminAdvert> advertsDto = adverts.Select(a => new UserManagementAdminAdvert
            {
                Date = a.CreatedAt,
                Email = a.User.Email,
                ProductName = a.Product.Name,
                Quantity = a.Quantity,
                UnitPrice = a.UnitPrice,
            }).ToList();

            return Json(advertsDto);
        }

        [HttpGet, Authorize]
        public IActionResult GetRecentSellAdvertForAdmin()
        {
            List<AdvertSell> adverts = _userManagementService.GetRecentSellAdverts();

            List<UserManagementAdminAdvert> advertsDto = adverts.Select(a => new UserManagementAdminAdvert
            {
                Date = a.CreatedAt,
                Email = a.User.Email,
                ProductName = a.Product.Name,
                Quantity = a.Quantity,
                UnitPrice = a.UnitPrice,
            }).ToList();

            return Json(advertsDto);
        }

        [HttpGet, Authorize]
        public IActionResult GetAdminStatistics()
        {
            UserManagementStaticticsDto statistics = new UserManagementStaticticsDto
            {
                AmountWallet = _userManagementService.GetSystemBalance(),
                ActiveAdvertBuy = _userManagementService.GetActiveAdvertBuyCount(),
                ActiveAdvertSale = _userManagementService.GetActiveAdvertSellCount(),
                PurchasesCompleted = _userManagementService.GetTransactionsCount(),
            };

            return Json(statistics);
        }

        [HttpGet, Authorize]
        public IActionResult GetCustomers()
        {
            List<UserManagementCustormersDto> customers = _userManagementService.GetAllUser().Select(u => new UserManagementCustormersDto
            {
                Name = u.Name,
                Surname = u.Surname,
                Email = u.Email,
                CoinAccountId = u.CoinAccountId.ToString(),
                Balance = _userManagementService.GetUserBalanceById(u.Id)
            }).ToList();

            return Json(customers);
        }
    }
}
