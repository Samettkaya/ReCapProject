﻿using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs
{
   public  class FilterDto:IDto
    {
        public int? BrandId { get; set; }
        public int? ColorId { get; set; }
        public int? ModelYear { get; set; }
        public int? Id { get; set; }
    }
}
