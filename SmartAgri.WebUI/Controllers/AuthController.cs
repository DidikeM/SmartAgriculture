using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SmartAgri.Business.Abstract;
using SmartAgri.Entities.Concrete;
using SmartAgri.WebUI.DTOs;
using SmartAgri.WebUI.JwtFeatures;
using System.IdentityModel.Tokens.Jwt;

namespace SmartAgri.WebUI.Controllers
{
    public class AuthController : Controller
    {
        private readonly JwtHandler _jwtHandler;
        private readonly IUserService _userService;
        public AuthController(JwtHandler jwtHandler, IUserService userService)
        {
            _jwtHandler = jwtHandler;
            _userService = userService;
        }

        [HttpPost]
        public IActionResult Login([FromBody] UserForAuthenticationDto userForAuthentication)
        {
            var user =  _userService.GetUserByEmail(userForAuthentication.Email);
            if (user == null || !_userService.CheckPassword(user, userForAuthentication.Password))
                return Unauthorized(new AuthResponseDto { ErrorMessage = "Invalid Authentication" });
            var signingCredentials = _jwtHandler.GetSigningCredentials();
            var claims = _jwtHandler.GetClaims(user);
            var tokenOptions = _jwtHandler.GenerateTokenOptions(signingCredentials, claims);
            var token = new JwtSecurityTokenHandler().WriteToken(tokenOptions);
            return Ok(new AuthResponseDto { IsAuthSuccessful = true, Token = token });
        }

        [AllowAnonymous]
        [HttpPost]
        public IActionResult Register([FromBody] UserForRegistrationDto userForRegistration)
        {
            var user = new User
            {
                Email = userForRegistration.Email,
                Name = userForRegistration.Name,
                Surname = userForRegistration.Surname,
                Password = userForRegistration.Password,
            };

            if (_userService.CreateUser(user))
            {
                return Ok(new RegistrationResponseDto { IsSuccessfulRegistration = true });
            }

            return BadRequest(new RegistrationResponseDto { IsSuccessfulRegistration = false });
        }
    }
}
