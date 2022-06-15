using Core.Utilities.Result;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICarImageService
    {
        public IResult Add(CarImage carImage);
        public IResult Delete(CarImage carImage);
        public IResult Update(CarImage carImage);
        public IDataResult<List<CarImage>> GetAll();
    }
}
