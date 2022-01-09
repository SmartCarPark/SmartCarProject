using BusinessLayer.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ISpotService  : IGenericService<Spot>
    {
        List<Spot> GetListByParkID(int parkID);
        void UpdateFulById(int id);
    }
}
