using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class ReservationManager : IReservationService
    {
        IReservatiınDal _reservationDal;

        public ReservationManager(IReservatiınDal reservationDal)
        {
            _reservationDal = reservationDal;
        }

        public Reservation GetByID(int id)
        {
            return _reservationDal.Get(x => x.reservationId == id);
        }

        public List<Reservation> GetList()
        {
            return _reservationDal.GetAll();
        }

        public List<Reservation> GetListByUserID(int id)
        {
            return _reservationDal.GetAll(x => x.userId == id);
        }

        public void TAdd(Reservation t)
        {
            _reservationDal.Add(t);
        }

        public void TDelete(Reservation t)
        {
            _reservationDal.Delete(t);
        }

        public void TUpdate(Reservation t)
        {
            _reservationDal.Update(t);
        }
    }
}
