using System.Security.Principal;

namespace SmartAgri.WebUI.DTOs
{
    public class UserManagementCustormersDto
    {
        public string Name { get; set; } = null!;
        public string Surname { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string CoinAccountId { get; set; } = null!;
        public decimal Balance { get; set; }
    }
}
