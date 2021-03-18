using Core.Entities;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs
{
    class CarDetailAndImagesDto:IDto
    {
        public CarDetailDto Car { get; set; }
        public List<CarImage> CarImages { get; set; }
    }
}
