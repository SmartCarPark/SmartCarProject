using BusinessLayer.Abstract;
using Core.Entities.Concrete;
using Entities.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IUserService : IGenericService<User>
    {
        List<ProfileDto> GetUser(int id);
    }
}
