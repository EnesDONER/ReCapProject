﻿using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Dtos
{
    public class CarDetailDto:IDto
    {
        public int Id { get; set; }
        public string BrandName { get; set; }
        public string ColorName { get; set; }
        public string Description { get; set; }
        public int ModelYear { get; set; }
        public decimal DailyPrice { get; set; }
        public int ColorId { get; set; }
        public int BrandId { get; set; }

    } 
}
