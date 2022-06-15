using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entity.Concrete
{
    public class Customer:IEntity
    {
        //UserId,CompanyName
        //  public int Id { get; set; }
        //user ıd db'de pk olmalı bir user birden fazla müşteri olamaz.
        public int Id { get; set; }
        public int UserId { get; set; }
        public string CompanyName { get; set; }
    }
}
