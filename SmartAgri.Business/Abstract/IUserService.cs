using SmartAgri.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Diagnostics.SymbolStore;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartAgri.Business.Abstract
{
    public interface IUserService
    {
        bool CheckPassword(User user, string? password);
        bool CreateUser(User user);
        User GetUserByEmail(string? email);
        bool CheckUser(string? email);
        bool ChangePassword(string? email, string? password);
	}
}
