using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class ParkManager : IParkService
    {
        IParkDal _parkDal;

        public ParkManager(IParkDal parkDal)
        {
            _parkDal = parkDal;
        }

        public Park GetByID(int id)
        {
            return _parkDal.Get(x => x.ParkId == id);
        }

        public List<Park> GetList()
        {
            return _parkDal.GetAll();
        }

        public void TAdd(Park t)
        {
            _parkDal.Add(t);
        }

        public void TDelete(Park t)
        {
            _parkDal.Delete(t);
        }

        public void TUpdate(Park t)
        {
            _parkDal.Update(t);
        }
    }
}
