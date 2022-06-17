using Business.Abstract;
using Business.Constants;
using Core.Utilities.Business;
using Core.Utilities.FileHelper;
using Core.Utilities.Result;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Entity.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CarImageManager : ICarImageService
    {
        ICarImageDal _carImageDal;
        IFileHelper _fileHelper;

        public CarImageManager(ICarImageDal carImageDal, IFileHelper fileHelper)
        {
            _carImageDal = carImageDal;
            _fileHelper = fileHelper;
        }

        public IResult Add(CarImage carImage, IFormFile file)
        {
            IResult result = BusinessRules.Run(CheckIfImageLimitExceeded(carImage.CarId));
            if(result != null)
            {
                return result;
            }

            var fileResult = _fileHelper.Upload(file, StaticUploadRoot.ImagePath);
            if (fileResult.Success)
            {
                var fileName = fileResult.Message;
                var filePath = StaticUploadRoot.ImagePath + fileName;
                carImage.ImagePath = filePath;
                carImage.Date = DateTime.Now;

                _carImageDal.Add(carImage);
                return new SuccessResult();
            }
            return new ErrorResult("Yükleme başarısız");
            
        }

        public IResult Delete(CarImage carImage)
        {
            var dbObject = _carImageDal.Get(c => c.CarId == carImage.CarId && c.ImagePath == carImage.ImagePath);
            if(dbObject != null)
            {
                carImage= dbObject;
                IResult result = _fileHelper.Delete(carImage.ImagePath);
                if (result.Success)
                {
                    _carImageDal.Delete(carImage);
                    return result;
                }
                return result;
            }
            return new ErrorResult();
        }

        public IResult Update(CarImage carImage, IFormFile file)
        {
            var dbObject = _carImageDal.Get(c => c.CarId == carImage.CarId && c.ImagePath == carImage.ImagePath);
            if(dbObject != null)
            {
                carImage = dbObject;
                IResult result = _fileHelper.Update(file,carImage.ImagePath, StaticUploadRoot.ImagePath);
                if (result.Success)
                {
                    carImage.ImagePath = StaticUploadRoot.ImagePath + result.Message;
                    _carImageDal.Update(carImage);
                    return result;
                }
            }
            return new ErrorResult();
        }

        public IDataResult<List<CarImage>> GetAll()
        {
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll());
        }

        public IDataResult<List<CarImage>> GetByCarId(int id)
        {
            var result = BusinessRules.Run(CheckIfAnyImageExists(id));
            if (result != null)
            {
                return new ErrorDataResult<List<CarImage>>(GetDefaultImage(id));
            }
            else
            {
                return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll(c => c.CarId == id));
            }
        }

        public IDataResult<CarImage> GetById(int id)
        {
            return new SuccessDataResult<CarImage>(_carImageDal.Get(i => i.Id == id));
        }

        private IResult CheckIfImageLimitExceeded(int carId)
        {
            var result = _carImageDal.GetAll(p => p.CarId == carId);
            if (result.Count >= 5)
            {
                return new ErrorResult("Maksimum fotoğraf sınırına ulaşıldı");
            }
            return new SuccessResult();
        }

        private IResult CheckIfAnyImageExists(int id)
        {
            var result = _carImageDal.GetAll(c => c.CarId == id);
            if (result.Any())
            {
                return new SuccessResult();
            }
            return new ErrorResult();
        }

        private List<CarImage> GetDefaultImage(int id)
        {
            List<CarImage> defaultImage = new List<CarImage>();
            defaultImage.Add(new CarImage
            {
                CarId = id,
                Date = DateTime.Now,
                ImagePath = StaticImageRoot.ImagePath + "DefaultImage.jpg"
            });
            return defaultImage;
        }

        public IDataResult<List<CarImageListDto>> GetCarImageList(int id)
        {
            return new SuccessDataResult<List<CarImageListDto>>(_carImageDal.GetCarImageList(c => c.CarId == id));
        }
    }
}
