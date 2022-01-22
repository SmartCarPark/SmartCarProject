using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Dto
{
    public class ProfileD
    {
        public User user { get; set; }
        public List<ProfileDto> profile { get; set; }
    }
}
