﻿using SmartAgri.Business.Abstract;
using SmartAgri.DataAccess.Abstract;
using SmartAgri.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartAgri.Business.Concrete
{
    public class UserService : IUserService
    {
        private readonly IUserDal _userDal;
        public UserService(IUserDal userDal)
        {
            _userDal = userDal;
        }
        public bool CheckPassword(User user, string? password)
        {
            return user.Password == password;
        }

        public bool CreateUser(User user)
        {
            if (_userDal.Any(u => u.Email == user.Email))
                return false;
            _userDal.Add(user);
            return true;
        }

        public bool CheckUser(string? email)
        {
			return _userDal.Any(u => u.Email == email);
		}

		public User GetUserByEmail(string? email)
        {
            return _userDal.Get(u => u.Email == email);
        }
		public bool ChangePassword(string? email, string? password)
		{
			var user = _userDal.Get(u => u.Email == email);
			user.Password = password!;
			_userDal.Update(user);
			return true;
		}
	}
}
