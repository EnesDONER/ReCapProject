using Core.Entities;
using DataAccess.Abstract;
using DataAccess.Dtos;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete
{
    public class InMemoryCarDal : ICarDal //IEntityRepository<Car>,
    {
        List<Car> _cars;
        public InMemoryCarDal()
        {
            _cars = new List<Car>
            {
                new Car { Id = 1, BrandId = 2, ColorId = 5, DailyPrice = 300, ModelYear = 2001, Description = "arac1" },
                new Car { Id = 2, BrandId = 1, ColorId = 2, DailyPrice = 350, ModelYear = 2005, Description = "arac2" },
                new Car { Id = 3, BrandId = 2, ColorId = 1, DailyPrice = 325, ModelYear = 2003, Description = "arac3" },
                new Car { Id = 4, BrandId = 3, ColorId = 5, DailyPrice = 500, ModelYear = 2022, Description = "arac4" },
                new Car { Id = 5, BrandId = 1, ColorId = 4, DailyPrice = 400, ModelYear = 2020, Description = "arac5" },
                new Car { Id = 6, BrandId = 2, ColorId = 5, DailyPrice = 300, ModelYear = 2015, Description = "arac6" },


             };
        }

        public void Add(Car entity)
        {
            _cars.Add(entity);
        }

        public void Delete(Car entity)
        {
            Car carToDelete = _cars.SingleOrDefault(c => c.Id == entity.Id);
            _cars.Remove(carToDelete);
        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            return _cars;
        }

        public List<CarDetailDto> GetCarDetails()
        {
            throw new NotImplementedException();
        }

        public List<CarDetailDto> GetCarDetails(Expression<Func<CarDetailDto, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public void Update(Car entity)
        {
            Car carToDelete = _cars.SingleOrDefault(c => c.Id == entity.Id);
            carToDelete.BrandId = entity.BrandId;
            carToDelete.ColorId = entity.ColorId;
            carToDelete.DailyPrice = entity.DailyPrice;
            carToDelete.Description = entity.Description;
            carToDelete.ModelYear = entity.ModelYear;

        }
    }
}
