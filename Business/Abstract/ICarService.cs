using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using Entities.DTOs;
using DataAccess.Dtos;
using Core.Utilities.Results;

namespace Business.Abstract
{
    public interface ICarService
    {
        IDataResult<List<Car>> GetAll();
        IDataResult<List<Car>> GetCarsByBrandId(int id);
        IDataResult<List<Car>> GetCarsByColorId(int id);
        IDataResult<Car> GetCarById(int id);
        IDataResult<List<CarDetailDto>> GetCarDetailsAll();
        IDataResult<List<CarDetailDto>> GetCarDetailsByCarId(int id);
        IDataResult<List<CarDetailDto>> GetCarDetailsByBrandName(string brandName);
        IDataResult<List<CarDetailDto>> GetCarDetailsByColorName(string colorName);
        IDataResult<List<CarDetailDto>> GetCarDetailsByFilter(int carId, string brandName, string colorName);
        IResult Add(Car car);
        IResult Update(Car car);
        IResult Delete(Car car);
    }
}
