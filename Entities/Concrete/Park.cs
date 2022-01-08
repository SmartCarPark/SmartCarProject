using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class Park : IEntity
    {
        public int ParkId { get; set; }
        public string ParkName { get; set; }
        public int capacity { get; set; }
        public bool  status { get; set; }
    }
}
