using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Core.DataAccess.EntityFramework;
using Entities.DTOs;
using DataAccess.Dtos;

//Hem EntityRepository hem EfEntityRepositoryBase referanslarını tutabildiği için here iki sınıfında metodlarını kullanabilir

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, ReCapDbContext>, ICarDal
    {//sınıfa özgün metodlar burada yazılır
        public List<CarDetailDto> GetCarDetails(Expression<Func<CarDetailDto, bool>> filter = null)
        {//Brands ve Colors tablolarını join operasyonuyla Cars tablosuna view benzeri işlevi gerçekleştirmek için yazıldı
            using (ReCapDbContext context = new ReCapDbContext())
            {
                var result = from c in context.Cars
                    join b in context.Brands on c.BrandId equals b.Id
                    join co in context.Colors on c.ColorId equals co.Id
                    select new CarDetailDto()
                    {
                        Id = c.Id, 
                        BrandName = b.Name,
                        ColorName = co.Name, 
                        Description = c.Description,
                        ModelYear = c.ModelYear, 
                        DailyPrice = c.DailyPrice
                    };
                return filter == null
                    ? result.ToList()
                    : result.Where(filter).ToList();
            }
        }
    }
}
