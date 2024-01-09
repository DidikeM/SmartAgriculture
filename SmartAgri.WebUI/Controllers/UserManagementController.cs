using Microsoft.AspNetCore.Mvc;
using SmartAgri.Business.Abstract;

namespace SmartAgri.WebUI.Controllers
{
    public class UserManagementController : Controller
    {
        private readonly IUserManagementService _userManagementService;
        public UserManagementController(IUserManagementService userManagementService)
        {
            _userManagementService = userManagementService;
        }

        public IActionResult GetBalanceForUser()
        {
          return Json(_userManagementService.GetUserBalanceById(GetClaim.GetUserId(User)));
        }

        public IActionResult BuyCredit(decimal amount)
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

        public IActionResult SellCredit(decimal amount)
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

        public IActionResult WithdrawCredit(string address,decimal amount)
        {
            string result;

            try
            {
                result = _userManagementService.WithdrawCreditFromUser(GetClaim.GetUserId(User), address, amount);
            }
            catch (Exception)
            {
                return BadRequest();
            }

            return Ok(result);
        }
    }
}
