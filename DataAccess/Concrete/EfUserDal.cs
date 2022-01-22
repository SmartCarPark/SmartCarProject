using Core.DataAccess.EntityFramework;
using Core.Entities.Concrete;
using DataAccess.Abstract;
using Entities.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq.Expressions;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete
{
    public class EfUserDal : EfEntityRepositoryBase<User, Context>, IUserDal
    {
        public List<ProfileDto> GetUser(int id)
        {
            using (var context = new Context())
            {
                var result = from res in context.Reservations
                             join user in context.Users
                             on res.userId equals user.ID
                             join spot in context.Spots
                             on res.spotId equals spot.spotId
                             where res.userId == id && res.status == true
                             select new ProfileDto { ParkName = spot.SpotName, BackParkName = spot.backup };
                return result.ToList();
            }
        }
    }
}
