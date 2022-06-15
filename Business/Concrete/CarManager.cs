using Business.Abstract;
using Business.Constans;
using Business.ValidationRules;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Result;
using DataAccess.Abstract;
using DataAccess.Dtos;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _ICarDal;
        public CarManager(ICarDal carDal)
        {
            _ICarDal = carDal;
        }
        [ValidationAspect(typeof(CarValidator))]
        public IResult Add(Car car)
        {
            if (car.Description.Length>2 && car.DailyPrice>0)
            {
                _ICarDal.Add(car);
                return new SuccessResult(Messages.ProductAdded);                
            }
            return new ErrorResult(Messages.ProductNameInvalid);
        }

        public IResult Delete(Car car)
        {
            _ICarDal.Delete(car);
            return new SuccessResult(Messages.ProductDeleted);            
        }

        public IDataResult<Car> Get(int Id)
        {
            return new SuccessDataResult<Car>(_ICarDal.Get(c=>c.Id==Id));
        }

        public IDataResult<List<Car>> GetAll()
        {
            if (DateTime.Now.Hour==24)
            {
                return new ErrorDataResult<List<Car>>();

            }
            return new SuccessDataResult<List<Car>>(_ICarDal.GetAll());

        }

        public IDataResult<Car> GetCarsByBrandId(int id)
        {
            return new SuccessDataResult<Car>(_ICarDal.Get(c => c.BrandId == id));
        }

        public IDataResult<Car> GetCarsByColorId(int id)
        {
            return new SuccessDataResult<Car>(_ICarDal.Get(c => c.ColorId == id));
        }

        public IDataResult<List<CarDetailDto>> GetCarsDetalis()
        {
            return new SuccessDataResult<List<CarDetailDto>>(_ICarDal.GetCarDetails());
        }


    }
}
