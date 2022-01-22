using Business.Abstract;
using Core.Entities.Concrete;
using DataAccess.Abstract;
using Entities.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class UserManager : IUserService
    {
        IUserDal _userDal;

        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }

        public User GetByID(int id)
        {
            return _userDal.Get(x => x.ID == id);
        }

        public List<User> GetList()
        {
            return _userDal.GetAll();
        }

        public List<ProfileDto> GetUser(int id)
        {
            return _userDal.GetUser(id);
        }

        public void TAdd(User t)
        {
            _userDal.Add(t);
        }

        public void TDelete(User t)
        {
            _userDal.Delete(t);
        }

        public void TUpdate(User t)
        {
            _userDal.Update(t);
        }

        public User UserExist(LoginDto login)
        {
            var user = _userDal.Get(x => x.Email == login.UserName && x.Password == login.Password);
            return user;
        }
    }
}
