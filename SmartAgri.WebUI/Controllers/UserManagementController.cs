using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SmartAgri.Business.Abstract;
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
          return Json(_userManagementService.GetUserBalanceById(GetClaim.GetUserId(User)));
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
    }
}
