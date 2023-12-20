using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using SmartAgri.Entities.Concrete;
using SmartAgri.Entities.Enums;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace SmartAgri.WebUI.JwtFeatures
{
    public class JwtHandler
    {
        private readonly IConfigurationSection _jwtSettings;
        public JwtHandler(IConfiguration configuration)
        {
            _jwtSettings = configuration.GetSection("JwtSettings");
        }

        public SigningCredentials GetSigningCredentials()
        {
            var key = Encoding.UTF8.GetBytes(_jwtSettings.GetSection("securityKey").Value!);
            var secret = new SymmetricSecurityKey(key);
            return new SigningCredentials(secret, SecurityAlgorithms.HmacSha256);
        }

        public List<Claim> GetClaims(User user)
        {
            var claims = new List<Claim>
            {
                new Claim(UserClaimEnum.id.ToString(), user.Id.ToString()),
                new Claim(UserClaimEnum.email.ToString(), user.Email),
                new Claim(UserClaimEnum.role_id.ToString(), user.RoleId.ToString()),
                new Claim(UserClaimEnum.name.ToString(), user.Name),
                new Claim(UserClaimEnum.surname.ToString(), user.Surname)
            };
            return claims;
        }

        public JwtSecurityToken GenerateTokenOptions(SigningCredentials signingCredentials, List<Claim> claims)
        {
            var tokenOptions = new JwtSecurityToken(
                issuer: _jwtSettings["validIssuer"],
                audience: _jwtSettings["validAudience"],
                claims: claims,
                expires: DateTime.Now.AddMinutes(Convert.ToDouble(_jwtSettings["expiryInMinutes"])),
                signingCredentials: signingCredentials);
            return tokenOptions;
        }
		public JwtSecurityToken GenerateTokenOptions(List<Claim> claims)
		{
			var tokenOptions = new JwtSecurityToken(
				issuer: _jwtSettings["validIssuer"],
				audience: _jwtSettings["validAudience"],
				claims: claims,
				expires: DateTime.Now.AddMinutes(Convert.ToDouble(_jwtSettings["expiryInMinutes"])));
			return tokenOptions;
		}
	}
}
