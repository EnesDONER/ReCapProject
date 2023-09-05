using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Business.Constants;
using Entities.DTOs;
using Core.Aspects.Autofac.Validation;
using Business.ValidationRules;
using Core.Utilities.Results;
using DataAccess.Dtos;
using Business.BusinessAspects.Autofac;
using Core.Utilities.Business;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _carDal;
        IBrandService _brandService;
        public CarManager(ICarDal carDal , IBrandService brandService)
        {
            _carDal = carDal;
            _brandService = brandService;
        }

        [SecuredOperation("car.add,admin")]
        [ValidationAspect(typeof(CarValidator))]
        public IResult Add(Car car)
        {
            if (car.Description.Length >= 2 && car.DailyPrice > 0)
            {
                _carDal.Add(car);
                return new SuccessResult(Messages.CarAdded);
            }
            else
            {
                return new ErrorResult();
            }
        }

        public IResult Update(Car car)
        {
            _carDal.Update(car);
            return new SuccessResult();
        }

        public IResult Delete(Car car)
        {
            _carDal.Delete(car);
            return new SuccessResult(Messages.CarDeleted);
        }
        [ValidationAspect(typeof(CarValidator))]
        [SecuredOperation("admin")]
        public IDataResult<List<Car>> GetAll()
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll());
        }

        public IDataResult<List<Car>> GetCarsByBrandId(int id)
        {
            var result = _carDal.GetAll(p => p.BrandId == id);
            if (result.Any() == false)
            {
                return new ErrorDataResult<List<Car>>();
            }
            else
            {
                return new SuccessDataResult<List<Car>>(result);
            }
        }

        public IDataResult<List<Car>> GetCarsByColorId(int id)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(p => p.ColorId == id));
        }
        public IDataResult<Car> GetCarById(int id)
        {
            return new SuccessDataResult<Car>(_carDal.Get(c => c.Id == id));
        }

        public IDataResult<List<CarDetailDto>> GetCarDetailsAll()
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails());
        }

        public IDataResult<List<CarDetailDto>> GetCarDetailsByCarId(int id)
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails(c => c.Id == id));
        }

        public IDataResult<List<CarDetailDto>> GetCarDetailsByBrandName(string brandName)
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails(c => c.BrandName == brandName));
        }

        public IDataResult<List<CarDetailDto>> GetCarDetailsByColorName(string colorName)
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails(c => c.ColorName == colorName));
        }

        public IDataResult<List<CarDetailDto>> GetCarDetailsByFilter(int carId, string brandName, string colorName)
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails(c => c.Id == carId && c.BrandName == brandName && c.ColorName == colorName));
        }

        public IDataResult<List<CarDetailDto>> GetCarDetailsByColorId(int id)
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails(c => c.ColorId == id));
        }
        
        public IDataResult<List<CarDetailDto>> GetCarDetailsByBrandId(int id)
        {
            IResult result = BusinessRules.Run(CheckIfCarBrand(id));
            if (result != null)
            {
                return new ErrorDataResult<List<CarDetailDto>>();
            }
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails(c => c.BrandId == id));
        }
        private IResult CheckIfCarBrand(int id)
        {
            if (_carDal.GetCarDetails(c => c.BrandId == id).Any())
            {
                return new SuccessResult();
            }

            return new ErrorResult();
        }
    }
}
