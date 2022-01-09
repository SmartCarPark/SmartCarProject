using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class SpotManager : ISpotService
    {
        ISpotDal _spotDal;

        public SpotManager(ISpotDal spotdal)
        {
            _spotDal = spotdal;
        }

        public Spot GetByID(int id)
        {
            return _spotDal.Get(x => x.spotId == id);
        }

        public List<Spot> GetList()
        {
            return _spotDal.GetAll();
        }

        public List<Spot> GetListByParkID(int parkID)
        {
            return _spotDal.GetAll(x => x.parkId == parkID);
        }

        public void TAdd(Spot t)
        {
            _spotDal.Add(t);
        }

        public void TDelete(Spot t)
        {
            _spotDal.Delete(t);
        }

        public void TUpdate(Spot t)
        {
            _spotDal.Update(t);
        }

        public void UpdateFulById(int id)
        {
            Spot spot = _spotDal.Get(x => x.spotId == id);
            spot.ful = true;
            _spotDal.Update(spot);
        }
    }
}
