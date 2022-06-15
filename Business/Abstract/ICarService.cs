using Core.Utilities.Result;
using DataAccess.Dtos;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICarService
    {
        IDataResult<List<Car>> GetAll();
        IDataResult<Car> GetCarsByBrandId(int id);
        IDataResult<Car> GetCarsByColorId(int id);
        IDataResult<List<CarDetailDto>> GetCarsDetalis();
        IResult Add(Car car);
        IResult Delete(Car car);
        
    
    }
}
