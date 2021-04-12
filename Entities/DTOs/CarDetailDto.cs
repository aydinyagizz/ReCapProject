﻿using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs
{
    public class CarDetailDto:IDto //tablo olmadığı için IEntity veremeyiz.
    {
        public int CarId { get; set; }
        public string CarName { get; set; }
        public string BrandName { get; set; }
        public int ModelYear { get; set; }
        public int DailyPrice { get; set; }
    }
}