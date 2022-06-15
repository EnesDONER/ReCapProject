using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Dtos
{
    public class CarDetailDto:IDto
    {
        //CarName, BrandName, ColorName, DailyPrice
        public string Description { get; set; }
        public string BrandName { get; set; }
        public string ColorName { get; set; }
        public int DailyPrice { get; set; }
    }
}
