using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    internal class Spot : IEntity
    {
        public int spotId { get; set; }
        public int parkId { get; set; }
        public Boolean broken { get; set; }
    }
}
