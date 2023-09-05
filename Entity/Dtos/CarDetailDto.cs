using Core.Entities;
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
<<<<<<<< HEAD:Entity/Dtos/CarDetailDto.cs
        public int ColorId { get; set; }
        public int BrandId { get; set; }
========
>>>>>>>> 0c2c9e3b3638e56b80726f23d722f5bc451a3e71:DataAccess/Dtos/CarDetailDto.cs
    } 
}
