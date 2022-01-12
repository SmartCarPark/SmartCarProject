using BusinessLayer.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IReservationService :  IGenericService<Reservation>
    {
        List<Reservation> GetListByUserID(int id);
    }
}
