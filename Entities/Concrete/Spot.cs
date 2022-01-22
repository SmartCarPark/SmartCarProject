using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class Spot : IEntity
    {
        public int spotId { get; set; }
        public int parkId { get; set; }
        public string SpotName { get; set; }
        public string backup { get; set; }
        public bool broken { get; set; }
        public bool ful { get; set; }
    }
}
