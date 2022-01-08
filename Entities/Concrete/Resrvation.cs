using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    internal class Resrvation :IEntity
    {
        public int reservationId { get; set; }
        public int spotId { get; set; }
        public int userId { get; set; }
        public DateTime date { get; set; }
    }

}
