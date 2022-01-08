using BusinessLayer.Abstract;
using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IUserService : IGenericService<User>
    {
    }
}
