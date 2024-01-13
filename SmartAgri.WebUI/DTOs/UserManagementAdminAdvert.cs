using SmartAgri.Entities.Concrete;
using static System.Formats.Asn1.AsnWriter;

namespace SmartAgri.WebUI.DTOs
{
    public class UserManagementAdminAdvert
    {
        public string ProductName { get; set; } = null!;
        public decimal UnitPrice { get; set; }
        public int Quantity { get; set; }
        public DateTime Date { get; set; }
        public string Email { get; set; } = null!;
    }
}
