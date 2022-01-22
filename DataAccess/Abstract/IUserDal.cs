using Core.DataAccess;
using Core.Entities.Concrete;
using Entities.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Abstract
{
    public interface IUserDal : IEntityRepository<User>
    {
        List<ProfileDto> GetUser(int id);
    }
}
