using SmartAgri.Entities.Enums;
using System.Security.Claims;

namespace SmartAgri.WebUI
{
    public class GetClaim
    {
        public static int GetUserId(ClaimsPrincipal user)
        {
            return int.Parse(user.Claims.FirstOrDefault(c => c.Type == UserClaimEnum.id.ToString())?.Value ?? "0");
        }
    }
}
