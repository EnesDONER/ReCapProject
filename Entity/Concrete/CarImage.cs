using Core.Entities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entity.Concrete
{
    public class CarImage:IEntity
    {
        //Id,CarId,ImagePath,Date
        public int Id { get; set; }
        public int CarId { get; set; }
        public IFormFile ImagePath { get; set; }
        public DateTime Date { get; set; }

    }
}
